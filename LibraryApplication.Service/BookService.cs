using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Service.Interfaces;

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

    public async Task<List<BookEntity>> GetAll()
    {
        return await _bookRepository.GetAll();
    }

    public async Task<int> Create(BookEntity entity)
    {
        return await _bookRepository.Create(entity);
    }

    public async Task<BookEntity> GetById(int id)
    {
        return await _bookRepository.GetById(id);
    }

    public async Task<bool> Update(int id, BookEntity entity)
    {
        return await _bookRepository.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _bookRepository.Delete(id);
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

        userEntity.Balance -= totalRentPrice;
        bookEntity.IsAvailable = false;

        await _bookRepository.CreateBookTransfer(bookId, userId, true, discountId, rentTimeInDays);
        await _bookRepository.Update(bookId, bookEntity);
        await _userRepository.Update(userId, userEntity);
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

        bookEntity.IsAvailable = true;
        await _bookRepository.CreateBookTransfer(bookId, userId, true, -1, -1);
        await _bookRepository.Update(bookId, bookEntity);
        await _userRepository.Update(userId, userEntity);
        return true;
    }

    public async Task<IEnumerable<BookEntity>> GetBorrowedBooks(int userId)
    {
        return await _bookRepository.GetBorrowedBooksByUser(userId);
    }
}