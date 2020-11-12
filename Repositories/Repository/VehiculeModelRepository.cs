using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using Repositories.Interfaces;

namespace Repositories.Repository
{
    /// <summary>
    /// Repository pour les opérations crud sur les models des véhicules  
    /// </summary>
    public class VehiculeModelRepository:BaseRepository<ModelVehicule>, IModelRepository
    {
        /// <summary>
        /// Contructeur model véhicule
        /// </summary>
        /// <param name="context"> Application context</param>
        public VehiculeModelRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
