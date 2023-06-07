using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IUserRepository : IBaseCrudRepository<UserEntity>
{
    double GetUserBalance(int id);

    IEnumerable<UserBalanceTransferEntity> GetUserBalanceHistory(int id);

    bool CheckIfExistingUser(string login, string password);
}