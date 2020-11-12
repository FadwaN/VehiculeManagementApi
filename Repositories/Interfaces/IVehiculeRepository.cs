using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Repository pour les opérations crud sur les véhicule  
    /// </summary>
    public interface IVehiculeRepository: IRepository<Vehicule>
    {
    }
}
