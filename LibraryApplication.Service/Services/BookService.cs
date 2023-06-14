﻿using AutoMapper;
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

    public async Task<bool> TryBorrowBook(int bookId, int userId, int? discountId, int rentTimeInDays)
    {
        var userEntity = await userRepository.GetById(userId);
        var bookEntity = await bookRepository.GetById(bookId);

        if (userEntity is null || bookEntity is null || !bookEntity.IsAvailable)
        {
            return false;
        }

        double totalRentPrice = bookEntity.RentPrice;
        
        if (discountId is not null)
        {
            var discountEntity = await discountRepository.GetById((int)discountId);
            totalRentPrice = bookEntity.RentPrice - (discountEntity?.Amount ?? 0);
        }

        if (userEntity.Balance < totalRentPrice)
        {
            return false;
        }

        await bookRepository.CreateBookTransfer(bookId, userId, true, discountId, rentTimeInDays);
        await bookRepository.MarkBookAsBorrowed(bookId);
        await userRepository.UpdateUserBalance(userId, userEntity.Balance - totalRentPrice);
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

        await bookRepository.CreateBookTransfer(bookId, userId, true, -1, -1);
        await bookRepository.MarkBookAsAvailable(bookId);
        return true;
    }
}