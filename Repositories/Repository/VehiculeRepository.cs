using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using Repositories.Interfaces;

namespace Repositories.Repository
{
    public class VehiculeRepository: BaseRepository<Vehicule>, IVehiculeRepository
    {
        public VehiculeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
