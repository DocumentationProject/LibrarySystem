namespace LibraryApplication.Data.Interfaces.Services;

public interface IAdminService
{
    Task GenerateFinesPastDueDate(int amount);
    Task<bool> GenerateFineForBookDamage(int bookId, int amount);
    Task<bool> AddDiscount(int userCategoryId, int discountTypeId);
}