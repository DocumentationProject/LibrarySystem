using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IUserRepository : IBaseCrudRepository<UserEntity>
{
    Task<int> UpdateUserBalance(int id, double amount);

    Task<IEnumerable<UserBalanceTransferEntity>> GetUserBalanceHistory(int id);

    Task<bool> CheckIfExistingUser(string login, string password);
}