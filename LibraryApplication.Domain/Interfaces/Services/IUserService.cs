namespace LibraryApplication.Data.Interfaces.Services;

public interface IUserService
{
    Task<int?> Authenticate(string userInput, string passwordInput);
    Task<bool> TryProcessFinePayment(int userId, int bookId);
    Task<bool> HasFines(int userId);
}