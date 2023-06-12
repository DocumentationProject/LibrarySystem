using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IUserRepository : IBaseCrudRepository<UserEntity>
{
    Task<double> UpdateUserBalance(int id, double amount);

    Task<List<UserBalanceTransferEntity>> GetUserBalanceHistory(int id);

    Task<int> CheckIfExistingUser(string login, string password);
}