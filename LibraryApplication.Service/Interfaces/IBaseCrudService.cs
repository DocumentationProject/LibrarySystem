namespace LibraryApplication.Service.Interfaces;

public interface IBaseCrudService<T>
{
    Task<List<T>> GetAll();

    Task<int> Create(T entity);

    Task<T> GetById(int id);
 
    Task<bool> Update(int id, T entity);

    Task<bool> Delete(int id);

}