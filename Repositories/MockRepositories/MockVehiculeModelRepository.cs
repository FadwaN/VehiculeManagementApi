using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainEntities;
using Repositories.Interfaces;

namespace Repositories.MockRepositories
{
    /// <summary>
    /// Class pour moquer le repository des models véhicules pour effectuer des test sans passer par la base de donnée.
    /// </summary>
    public class MockVehiculeModelRepository: IModelRepository
    {
        private readonly List<ModelVehicule> mockModelsList =new List<ModelVehicule>()
        {
            new ModelVehicule(){Description = "Description1", Id=1, Model = "Model1"},
            new ModelVehicule(){Description = "Description2", Id=2, Model = "Model2"},
            new ModelVehicule(){Description = "Description3", Id=3, Model = "Model3"},
            new ModelVehicule(){Description = "Description4", Id=4, Model = "Model4"},
        };
        public List<ModelVehicule> GetAll()
        {
            return mockModelsList;
        }

        public ModelVehicule Get(long id)
        {
            return mockModelsList.FirstOrDefault(x=>x.Id == id);
        }

        public void Insert(ModelVehicule entity)
        {
            mockModelsList.Add(entity);
        }

        public void Update(ModelVehicule entity)
        {
            var item = mockModelsList.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                mockModelsList.Remove(item);
                mockModelsList.Add(entity);
            }
        }

        public void Delete(ModelVehicule entity)
        {
            var item = mockModelsList.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                mockModelsList.Remove(item);
            }
        }

        public void SaveChanges()
        {
        }
    }
}
