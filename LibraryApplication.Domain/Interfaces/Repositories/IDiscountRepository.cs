using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IDiscountRepository : IBaseCrudRepository<DiscountEntity>
{
    int CreateDiscountByUserType(int amount, int userCategoryId);
}