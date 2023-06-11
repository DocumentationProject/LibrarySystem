namespace LibraryApplication.Service.Interfaces;

public interface IAdminService
{
    void GenerateFinesPastDueDate(int amount);
    void GenerateFineForBookDamage(int bookId, int amount);
    void AddDiscount(int userCategoryId, int discountTypeId);
}