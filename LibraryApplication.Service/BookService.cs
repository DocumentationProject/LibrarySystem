using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Data.Interfaces.Services;

namespace LibraryApplication.Service;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFineRepository _fineRepository;

    public BookService(IBookRepository bookRepository, IDiscountRepository discountRepository, IUserRepository userRepository, IFineRepository fineRepository)
    {
        _bookRepository = bookRepository;
        _discountRepository = discountRepository;
        _userRepository = userRepository;
        _fineRepository = fineRepository;
    }

    public Task<List<BookEntity>> GetAll()
    {
        return _bookRepository.GetAll();
    }

    public Task<int> Create(BookEntity entity)
    {
        return _bookRepository.Create(entity);
    }

    public Task<BookEntity> GetById(int id)
    {
        return _bookRepository.GetById(id);
    }

    public Task<bool> Update(int id, BookEntity entity)
    {
        return _bookRepository.Update(id, entity);
    }

    public Task<bool> Delete(int id)
    {
        return _bookRepository.Delete(id);
    }

    public Task<List<BookEntity>> GetBorrowedBooks(int userId)
    {
        return _bookRepository.GetBorrowedBooksByUser(userId);
    }

    public Task<List<BookEntity>> GetAllAvailableBooks()
    {
        return _bookRepository.GetAllAvailableBooks();
    }

    public async Task<bool> TryBorrowBook(int bookId, int userId, int discountId, int rentTimeInDays)
    {
        var userEntity = await _userRepository.GetById(userId);
        var bookEntity = await _bookRepository.GetById(bookId);
        var discountEntity = await _discountRepository.GetById(discountId);

        if (userEntity is null || bookEntity is null || !bookEntity.IsAvailable || discountEntity is null)
        {
            return false;
        }

        double totalRentPrice = bookEntity.RentPrice - discountEntity.Amount;

        if (userEntity.Balance < totalRentPrice)
        {
            return false;
        }

        await _bookRepository.CreateBookTransfer(bookId, userId, true, discountId, rentTimeInDays);
        await _bookRepository.MarkBookAsBorrowed(bookId);
        await _userRepository.UpdateUserBalance(userId, userEntity.Balance - totalRentPrice);
        return true;
    }

    public async Task<bool> TryReturnBook(int bookId, int userId)
    {
        var userEntity = await _userRepository.GetById(userId);
        var bookEntity = await _bookRepository.GetById(bookId);

        if (userEntity is null || bookEntity is null || bookEntity.IsAvailable)
        {
            return false;
        }

        var bookTransferEntity = bookEntity.BookTransfers.LastOrDefault(x => x.UserId == userId);

        if (bookTransferEntity == null || !bookTransferEntity.IsBorrowed)
        {
            return false;
        }

        var finesByUserId = await _fineRepository.GetFinesByUserId(userId);

        if (finesByUserId.Any(x => x.BookTransferId == bookTransferEntity.Id))
        {
            return false;
        }

        await _bookRepository.CreateBookTransfer(bookId, userId, true, -1, -1);
        await _bookRepository.MarkBookAsAvailable(bookId);
        await _userRepository.Update(userId, userEntity);
        return true;
    }
}