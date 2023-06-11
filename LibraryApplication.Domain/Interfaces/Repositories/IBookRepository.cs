using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IBookRepository : IBaseCrudRepository<BookEntity>
{
    void MarkBookAsBorrowed(int id);
    
    void MarkBookAsAvailable(int id);

    int CreateBookTransfer(int bookId, int userId, bool isBorrowed, int discountId, int rentTimeInDays);

    IEnumerable<BookEntity> GetAllBorrowedBooks();
    
    IEnumerable<BookEntity> GetAllAvailableBooks();
    
    IEnumerable<BookEntity> GetBorrowedBooksByUser(int userId);
}