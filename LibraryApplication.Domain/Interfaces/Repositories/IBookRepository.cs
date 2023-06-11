using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IBookRepository : IBaseCrudRepository<BookEntity>
{
    int MarkBookAsBorrowed(int id);
    
    int MarkBookAsAvailable(int id);

    int CreateBookTransfer(int bookId, int userId, bool isBorrowed, int discountId, int rentTimeInDays);

    IEnumerable<BookEntity> GetAllBorrowedBooks();
    
    IEnumerable<BookEntity> GetAllAvailableBooks();
    
    IEnumerable<BookEntity> GetBorrowedBooksByUser(int userId);
}