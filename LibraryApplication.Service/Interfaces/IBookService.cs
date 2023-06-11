using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Service.Interfaces;

public interface IBookService: IBaseCrudService<BookEntity>
{
    void BorrowBook(int bookId, int userId);
    void ReturnBook(int bookId, int userId);
    IEnumerable<BookEntity> GetBorrowedBooks(int userId);
    public void GetBorrowedBookList(int userId);
}