using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using InterfaceService.Interfaces;
using Repositories.Interfaces;

namespace InterfaceService.Implementations
{
    public class VehiculeService : IVehiculeService
    {
        private IVehiculeRepository vehiculeRepository;

        public VehiculeService(IVehiculeRepository vehiculeRepository)
        {
            this.vehiculeRepository = vehiculeRepository;
        }
        public List<Vehicule> GetAll()
        {
            return vehiculeRepository.GetAll();
        }

        public Vehicule Get(long id)
        {
            return vehiculeRepository.Get(id);
        }

        public void Insert(Vehicule vehicule)
        {
            vehiculeRepository.Insert(vehicule);
        }

        public void Update(Vehicule vehicule)
        {
            vehiculeRepository.Update(vehicule);
        }

        public void Delete(Vehicule vehicule)
        {
            vehiculeRepository.Delete(vehicule);
        }
    }
}
