using AutoMapper;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Data.Interfaces.Services;

namespace LibraryApplication.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IFineRepository fineRepository;
    private readonly IMapper mapper;

    public UserService(
        IUserRepository userRepository,
        IFineRepository fineRepository, 
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.fineRepository = fineRepository;
        this.mapper = mapper;
    }

    public Task<int?> Authenticate(string userInput, string passwordInput)
    {
        return userRepository.GetUserIdByLoginAndPassword(userInput, passwordInput);
    }

    public async Task<bool> HasFines(int userId)
    {
        return (await fineRepository.GetFinesByUserId(userId)).Any();
    }

    public async Task<bool> TryProcessFinePayment(int userId, int bookId)
    {
        var fineEntity = (await fineRepository.GetFinesByUserId(userId)).FirstOrDefault(x => x.BookTransferEntity.BookId == bookId);

        if (fineEntity is null)
        {
            return false;
        }

        var updateResult = await userRepository.UpdateUserBalance(userId, -fineEntity.Amount);
        var deleteResult = await fineRepository.Delete(fineEntity.Id);
        return updateResult is not null || deleteResult;
    }
}