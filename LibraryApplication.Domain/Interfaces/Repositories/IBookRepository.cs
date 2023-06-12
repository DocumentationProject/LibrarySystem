﻿using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IBookRepository : IBaseCrudRepository<BookEntity>
{
    Task<bool> MarkBookAsBorrowed(int id);
    
    Task<bool> MarkBookAsAvailable(int id);

    Task<int> CreateBookTransfer(int bookId, int userId, bool isBorrowed, int discountId, int rentTimeInDays);

    Task<List<BookEntity>> GetAllBorrowedBooks();
    
    Task<List<BookEntity>> GetAllAvailableBooks();
    
    Task<List<BookEntity>> GetBorrowedBooksByUser(int userId);
}