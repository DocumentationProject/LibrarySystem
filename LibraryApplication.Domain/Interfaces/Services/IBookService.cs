using LibraryApplication.Data.Models;

namespace LibraryApplication.Data.Interfaces.Services;

public interface IBookService : IBaseCrudService<BookModel>
{
    Task<bool> TryBorrowBook(int bookId, int userId, int? discountId, int rentTimeInDays);
    Task<bool> TryReturnBook(int bookId, int userId);
    Task<List<BookModel>> GetAvailableBooks();
    Task<List<BookModel>> GetBorrowedBooksByUser(int userId);
}