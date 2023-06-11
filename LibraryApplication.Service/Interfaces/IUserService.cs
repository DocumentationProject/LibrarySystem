using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Service.Interfaces;

public interface IUserService : IBaseCrudService<UserEntity>
{
    double GetUserBalance(int userId);
    IEnumerable<UserBalanceTransferEntity> GetUserBalanceHistory(int userId);
    int Authenticate(string userInput, string passwordInput);
    void ProcessAccountTopUp(int userId, double amount);
    void ProcessFinePayment(int userId, int bookId);
    bool HasFines(int userId);
}