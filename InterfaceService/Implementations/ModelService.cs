using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using InterfaceService.Interfaces;
using Repositories.Interfaces;

namespace InterfaceService.Implementations
{
    public class ModelService : IModelService
    {
        private IModelRepository modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }
        public List<ModelVehicule> GetAll()
        {
            return modelRepository.GetAll();
        }

        public ModelVehicule Get(long id)
        {
            return modelRepository.Get(id);
        }

        public void Insert(ModelVehicule model)
        {
            modelRepository.Insert(model);
        }

        public void Update(ModelVehicule model)
        {
            modelRepository.Update(model);
        }

        public void Delete(ModelVehicule model)
        {
            modelRepository.Delete(model);
        }
    }
}
