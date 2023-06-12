using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Services;

public interface IUserService : IBaseCrudService<UserEntity>
{
    Task<double?> GetUserBalance(int userId);
    Task<List<UserBalanceTransferEntity>> GetUserBalanceHistory(int userId);
    Task<int> Authenticate(string userInput, string passwordInput);
    Task ProcessAccountTopUp(int userId, double amount);
    Task<bool> TryProcessFinePayment(int userId, int bookId);
    Task<bool> HasFines(int userId);
    Task<List<UserBalanceTransferEntity>> GetReportByUserId(int userId);
}