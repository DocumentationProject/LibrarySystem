using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Services;

public interface IBookService: IBaseCrudService<BookEntity>
{
    Task<bool> TryBorrowBook(int bookId, int userId, int discountId, int rentTimeInDays);
    Task<bool> TryReturnBook(int bookId, int userId);
    Task<List<BookEntity>> GetBorrowedBooks(int userId);
    Task<List<BookEntity>> GetAllAvailableBooks();
}