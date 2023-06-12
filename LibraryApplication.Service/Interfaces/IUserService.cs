using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Service.Interfaces;

public interface IUserService : IBaseCrudService<UserEntity>
{
    Task<double?> GetUserBalance(int userId);
    Task<IEnumerable<UserBalanceTransferEntity>> GetUserBalanceHistory(int userId);
    Task<int> Authenticate(string userInput, string passwordInput);
    Task ProcessAccountTopUp(int userId, double amount);
    Task<bool> TryProcessFinePayment(int userId, int bookId);
    Task<bool> HasFines(int userId);
    Task<IEnumerable<UserBalanceTransferEntity>> GetReportByUserId(int userId);
}