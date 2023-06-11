using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IFineRepository : IBaseCrudRepository<FineEntity>
{
    Task<IEnumerable<FineEntity>> GetFinesByUserId(int userId);
}