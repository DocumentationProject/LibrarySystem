using AutoMapper;
using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Data.Interfaces.Services;
using LibraryApplication.Data.Models;

namespace LibraryApplication.Service.Services;

public class BookService : BaseCrudService<BookModel, BookEntity>, IBookService
{
    private readonly IBookRepository bookRepository;
    private readonly IDiscountRepository discountRepository;
    private readonly IUserRepository userRepository;
    private readonly IFineRepository fineRepository;

    public BookService(
        IBookRepository bookRepository, 
        IDiscountRepository discountRepository, 
        IUserRepository userRepository, 
        IFineRepository fineRepository, 
        IMapper mapper) 
        : base(bookRepository, mapper)
    {
        this.bookRepository = bookRepository;
        this.discountRepository = discountRepository;
        this.userRepository = userRepository;
        this.fineRepository = fineRepository;
    }

    public async Task<bool> TryBorrowBook(int bookId, int userId, int rentTimeInDays)
    {
        var userEntity = await userRepository.GetById(userId);
        var bookEntity = await bookRepository.GetById(bookId);

        if (userEntity is null || bookEntity is null)
        {
            return false;
        }

        double totalRentPrice = bookEntity.RentPrice;

        if (userEntity.Balance < totalRentPrice)
        {
            return false;
        }

        await bookRepository.CreateBookTransfer(bookId, userId, true, rentTimeInDays);
        await bookRepository.MarkBookAsBorrowed(bookId);
        await userRepository.UpdateUserBalance(userId, -1 * totalRentPrice);
        return true;
    }

    public async Task<bool> TryReturnBook(int bookId, int userId)
    {
        var bookEntity = await bookRepository.GetById(bookId);

        if (bookEntity is null || bookEntity.IsAvailable)
        {
            return false;
        }

        var bookTransferEntity = bookEntity.BookTransfers.LastOrDefault(x => x.UserId == userId);

        if (bookTransferEntity is not { IsBorrowed: true })
        {
            return false;
        }

        var finesByUserId = await fineRepository.GetFinesByUserId(userId);

        if (finesByUserId.Any(x => x.BookTransferId == bookTransferEntity.Id))
        {
            return false;
        }

        await bookRepository.CreateBookTransfer(bookId, userId, true, -1);
        await bookRepository.MarkBookAsAvailable(bookId);
        return true;
    }

    public async Task<List<BookModel>> GetAvailableBooks()
    {
        var books = await this.bookRepository.GetAllAvailableBooks();
        return this.Mapper.Map<List<BookModel>>(books);
    }

    public async Task<List<BookModel>> GetBorrowedBooksByUser(int userId)
    {
        var books = await this.bookRepository.GetBorrowedBooksByUser(userId);
        return this.Mapper.Map<List<BookModel>>(books);
    }
}