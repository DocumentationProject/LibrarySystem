using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IBookRepository : IBaseCrudRepository<BookEntity>
{
    Task<int> MarkBookAsBorrowed(int id);
    
    Task<int> MarkBookAsAvailable(int id);

    Task<int> CreateBookTransfer(int bookId, int userId, bool isBorrowed, int discountId, int rentTimeInDays);

    Task<IEnumerable<BookEntity>> GetAllBorrowedBooks();
    
    Task<IEnumerable<BookEntity>> GetAllAvailableBooks();
    
    Task<IEnumerable<BookEntity>> GetBorrowedBooksByUser(int userId);
}