using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainEntities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext context;
        protected DbSet<T> entities;
        protected string errorMessage = string.Empty;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }
        public virtual List<T> GetAll()
        {
            return entities.AsEnumerable().ToList();
        }

        public virtual T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
