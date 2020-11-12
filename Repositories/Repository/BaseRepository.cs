using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainEntities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Repository
{
    /// <summary>
    /// Class de base pour les repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext context;
        protected DbSet<T> entities;
        protected string errorMessage = string.Empty;

        /// <summary>
        /// Contructeur de repository
        /// </summary>
        /// <param name="context">Application context</param>
        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        /// <summary>
        /// Retourner une liste de tous les items dans cette repository
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            return entities.AsEnumerable().ToList();
        }

        /// <summary>
        /// Retourner l'item dont l'identifiant est id
        /// </summary>
        /// <param name="id">identifiant</param>
        /// <returns></returns>
        public virtual T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Insérer  un nouveau item dans la repository
        /// </summary>
        /// <param name="entity">L'item à insérer</param>
        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Mettre à jour un item.
        /// </summary>
        /// <param name="entity">L'item ajour</param>
        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Supprimer un item
        /// </summary>
        /// <param name="entity">l'item à supprimer</param>
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Sauvgarder les modifications dans la base.
        /// </summary>
        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
