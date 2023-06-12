using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Data.Interfaces.Services;

namespace LibraryApplication.Service;

public class AdminService : IAdminService
{
    private readonly IFineRepository _fineRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IDiscountRepository _discountRepository;

    public AdminService(
        IFineRepository fineRepository,
        IBookRepository bookRepository,
        IDiscountRepository discountRepository)
    {
        _fineRepository = fineRepository;
        _bookRepository = bookRepository;
        _discountRepository = discountRepository;
    }

    public async Task GenerateFinesPastDueDate(int amount)
    {
        foreach (BookEntity book in await _bookRepository.GetAllBorrowedBooks())
        {
            var bookTransferEntity = book.BookTransfers.LastOrDefault();
            if (bookTransferEntity is not null && bookTransferEntity.IsBorrowed && bookTransferEntity.ExpectedReturnDate <= DateTime.Now)
            {
                var finesByUserId = await _fineRepository.GetFinesByUserId(bookTransferEntity.UserEntity.Id);
                await CreateOrUpdateFine(amount, finesByUserId, bookTransferEntity);
            }
        }
    }

    public async Task<bool> GenerateFineForBookDamage(int bookId, int amount)
    {
        BookEntity bookEntity = await _bookRepository.GetById(bookId);

        if (bookEntity is null)
        {
            return false;
        }

        var bookTransferEntity = bookEntity.BookTransfers.LastOrDefault();

        if (bookTransferEntity is null)
        {
            return false;
        }

        List<FineEntity> finesByUserId = await _fineRepository.GetFinesByUserId(bookTransferEntity.UserEntity.Id);
        await CreateOrUpdateFine(amount, finesByUserId, bookTransferEntity);
        return true;
    }

    public async Task<bool> AddDiscount(int userCategoryId, int discountTypeId)
    {
        var discountEntity = await _discountRepository.GetById(discountTypeId);

        if (discountEntity is null)
        {
            return false;
        }

        return await _discountRepository.CreateDiscountByUserType(discountEntity.Amount, userCategoryId) != -1;
    }

    private async Task CreateOrUpdateFine(int amount, List<FineEntity> finesByUserId, BookTransferEntity bookTransferEntity)
    {
        var existingFine = finesByUserId.FirstOrDefault(x => x.BookTransferId == bookTransferEntity.Id);

        if (existingFine is null)
        {
            await _fineRepository.Create(new FineEntity
            {
                UserEntity = bookTransferEntity.UserEntity,
                BookTransferEntity = bookTransferEntity,
                BookTransferId = bookTransferEntity.Id,
                Date = DateTime.Now,
                UserId = bookTransferEntity.UserEntity.Id,
                Amount = amount,
            });
        }
        else
        {
            existingFine.Amount += amount;
            await _fineRepository.Update(existingFine.Id, existingFine);
        }
    }
}