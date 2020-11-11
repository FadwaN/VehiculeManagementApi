using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using Repositories.Interfaces;

namespace Repositories.Repository
{
    public class VehiculeModelRepository:BaseRepository<ModelVehicule>, IModelRepository
    {
        public VehiculeModelRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
