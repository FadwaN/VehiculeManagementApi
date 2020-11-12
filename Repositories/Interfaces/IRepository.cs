using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Class de base pour tous les repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
