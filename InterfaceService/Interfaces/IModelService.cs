using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;

namespace InterfaceService.Interfaces
{
    public interface IModelService
    {
        List<ModelVehicule> GetAll();
        ModelVehicule Get(long id);
        void Insert(ModelVehicule model);
        void Update(ModelVehicule model);
        void Delete(ModelVehicule model);
    }
}
