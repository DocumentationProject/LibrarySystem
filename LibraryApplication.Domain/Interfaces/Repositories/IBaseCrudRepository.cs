using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IBaseCrudRepository<T> where T:IEntityBase
{
    Task<List<T>> GetAll();

    Task<int> Create(T entity);

    Task<T> GetById();

    Task<int> Update(int id, T entity);

    Task<int> Delete(int id);
}