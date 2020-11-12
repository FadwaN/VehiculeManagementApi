using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainEntities;
using Repositories.Interfaces;

namespace Repositories.MockRepositories
{
    /// <summary>
    /// Class pour moquer le repository des véhicules pour effectuer des test sans passer par la base de donnée.
    /// </summary>
    public class MockVehiculeRepository: IVehiculeRepository
    {
        private readonly List<Vehicule> MockListVehicules = new List<Vehicule>()
        {
            new Vehicule(){Id = 1, Nom = "Vehicule1", Description = "Description1", ModelId = 1},
            new Vehicule(){Id = 2, Nom = "Vehicule2", Description = "Description2", ModelId = 2},
            new Vehicule(){Id = 3, Nom = "Vehicule3", Description = "Description3", ModelId = 3},
            new Vehicule(){Id = 4, Nom = "Vehicule4", Description = "Description4", ModelId = 4},
        };
        public List<Vehicule> GetAll()
        {
            return MockListVehicules;
        }

        public Vehicule Get(long id)
        {
            return MockListVehicules.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Vehicule entity)
        {
            MockListVehicules.Add(entity);
        }

        public void Update(Vehicule entity)
        {
            var vehicule = MockListVehicules.FirstOrDefault(x => x.Id == entity.Id);
            if (vehicule != null)
            {
                MockListVehicules.Remove(vehicule);
                MockListVehicules.Add(entity);
            }
        }

        public void Delete(Vehicule entity)
        {
            var vehicule = MockListVehicules.FirstOrDefault(x => x.Id == entity.Id);
            if (vehicule != null)
            {
                MockListVehicules.Remove(vehicule);
            }
        }

        public void SaveChanges()
        {
            
        }
    }
}
