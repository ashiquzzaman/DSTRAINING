using System;
using System.Collections.Generic;

namespace DSTRAINING.WEB.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        T Get(int id);
        T Create(T item);
        int Update(T item);
        void Delete(T item);
    }
}