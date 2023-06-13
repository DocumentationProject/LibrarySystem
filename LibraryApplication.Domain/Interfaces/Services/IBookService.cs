namespace LibraryApplication.Data.Interfaces.Services;

public interface IBookService
{
    Task<bool> TryBorrowBook(int bookId, int userId, int? discountId, int rentTimeInDays);
    Task<bool> TryReturnBook(int bookId, int userId);
}