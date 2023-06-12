using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Service.Interfaces;

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

    public async Task<List<UserEntity>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<int> Create(UserEntity entity)
    {
        return await _userRepository.Create(entity);
    }

    public async Task<UserEntity> GetById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<bool> Update(int id, UserEntity entity)
    {
        return await _userRepository.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _userRepository.Delete(id);
    }

    public async Task<IEnumerable<UserBalanceTransferEntity>> GetReportByUserId(int userId)
    {
        return await _userRepository.GetUserBalanceHistory(userId);
    }

    public async Task<double?> GetUserBalance(int userId)
    {
        return (await _userRepository.GetById(userId))?.Balance;
    }

    public async Task<IEnumerable<UserBalanceTransferEntity>> GetUserBalanceHistory(int userId)
    {
        return await _userRepository.GetUserBalanceHistory(userId);
    }

    public async Task<int> Authenticate(string userInput, string passwordInput)
    {
        var user = (await GetAll()).FirstOrDefault(x => x.Login == userInput && x.Password == passwordInput);

        if (user is null)
        {
            return -1;
        }

        return user.Id;
    }

    public async Task ProcessAccountTopUp(int userId, double amount)
    {
        var userEntity = await _userRepository.GetById(userId);
        if (userEntity is null)
        {
            return;
        }

        userEntity.Balance += amount;
        await _userRepository.Update(userId, userEntity);
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

        userEntity.Balance -= fineEntity.Amount;
        await _userRepository.Update(userId, userEntity);
        await _fineRepository.Delete(fineEntity.Id);
        return true;
    }

    public async Task<bool> HasFines(int userId)
    {
        return (await _fineRepository.GetFinesByUserId(userId)).Any();
    }
}