using LibraryApplication.Data.Database.Entities;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IFineRepository : IBaseCrudRepository<FineEntity>
{
    IEnumerable<FineEntity> GetFinesByUserId(int userId);
}