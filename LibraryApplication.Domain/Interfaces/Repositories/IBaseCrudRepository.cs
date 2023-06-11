﻿using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Interfaces.Repositories;

public interface IBaseCrudRepository<T> where T:IEntityBase
{
    IEnumerable<T> GetAll();

    T GetById(int id);

    int Update(int id, T entity);

    int Delete(int id);
}