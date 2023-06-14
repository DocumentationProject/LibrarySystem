using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Interfaces.Repositories;

namespace LibraryApplication.Infrastructure.Repositories;

public class DiscountRepository : BaseCrudRepository<DiscountEntity>, IDiscountRepository
{
    public DiscountRepository(LibraryApplicationDbContext dbContext) : base(dbContext)
    {
    }

    protected override void UpdateProps(DiscountEntity entityToUpdate, DiscountEntity passedEntity)
    {
        entityToUpdate.Name = passedEntity.Name;
        entityToUpdate.Amount = passedEntity.Amount;
    }

    public Task<int> CreateDiscountByUserType(int amount, int userCategoryId, string name = null)
    {
        DiscountEntity discount = new()
        {
            Amount = amount, 
            UserCategoryId = userCategoryId, 
            Name = name ?? $"Discount for {userCategoryId}"
        };

        return this.Create(discount);
    }
}