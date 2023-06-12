using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Data.Interfaces.Services;

namespace LibraryApplication.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFineRepository _fineRepository;

    public UserService(
        IUserRepository userRepository,
        IFineRepository fineRepository)
    {
        _userRepository = userRepository;
        _fineRepository = fineRepository;
    }

    public Task<List<UserEntity>> GetAll()
    {
        return _userRepository.GetAll();
    }

    public Task<int> Create(UserEntity entity)
    {
        return _userRepository.Create(entity);
    }

    public Task<UserEntity> GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public Task<bool> Update(int id, UserEntity entity)
    {
        return _userRepository.Update(id, entity);
    }

    public Task<bool> Delete(int id)
    {
        return _userRepository.Delete(id);
    }

    public Task<List<UserBalanceTransferEntity>> GetReportByUserId(int userId)
    {
        return _userRepository.GetUserBalanceHistory(userId);
    }

    public async Task<double?> GetUserBalance(int userId)
    {
        return (await _userRepository.GetById(userId))?.Balance;
    }

    public Task<List<UserBalanceTransferEntity>> GetUserBalanceHistory(int userId)
    {
        return _userRepository.GetUserBalanceHistory(userId);
    }

    public Task<int> Authenticate(string userInput, string passwordInput)
    {
        return _userRepository.CheckIfExistingUser(userInput, passwordInput);
    }

    public async Task<bool> HasFines(int userId)
    {
        return (await _fineRepository.GetFinesByUserId(userId)).Any();
    }

    public async Task ProcessAccountTopUp(int userId, double amount)
    {
        var userEntity = await _userRepository.GetById(userId);

        if (userEntity is null)
        {
            return;
        }

        await _userRepository.UpdateUserBalance(userId, userEntity.Balance + amount);
    }

    public async Task<bool> TryProcessFinePayment(int userId, int bookId)
    {
        var userEntity = await _userRepository.GetById(userId);

        if (userEntity is null)
        {
            return false;
        }

        var fineEntity = (await _fineRepository.GetFinesByUserId(userId)).FirstOrDefault(x => x.BookTransferEntity.BookId == bookId);

        if (fineEntity is null || fineEntity.Amount > userEntity.Balance)
        {
            return false;
        }

        await _userRepository.UpdateUserBalance(userId, userEntity.Balance - fineEntity.Amount);
        await _fineRepository.Delete(fineEntity.Id);
        return true;
    }
}