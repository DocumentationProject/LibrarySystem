using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Service.Interfaces;

public interface IBookService: IBaseCrudService<BookEntity>
{
    Task<bool> TryBorrowBook(int bookId, int userId, int discountId, int rentTimeInDays);
    Task<bool> TryReturnBook(int bookId, int userId);
    Task<IEnumerable<BookEntity>> GetBorrowedBooks(int userId);
}