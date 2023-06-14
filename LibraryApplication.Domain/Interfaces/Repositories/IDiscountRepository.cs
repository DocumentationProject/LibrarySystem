using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IDiscountRepository : IBaseCrudRepository<DiscountEntity>
{
     Task<int> CreateDiscountByUserType(int amount, int userCategoryId, string name = null);
}