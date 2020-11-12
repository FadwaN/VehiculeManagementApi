using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using Repositories.Interfaces;

namespace Repositories.Repository
{
    /// <summary>
    /// <summary>
    /// Repository pour les opérations crud sur les véhicules  
    /// </summary>
    public class VehiculeRepository: BaseRepository<Vehicule>, IVehiculeRepository
    {
        /// <summary>
        /// Constructeur  
        /// </summary>
        /// <param name="context">Application context</param>
        public VehiculeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
