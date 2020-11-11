using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;

namespace InterfaceService.Interfaces
{
    public interface IVehiculeService
    {
        List<Vehicule> GetAll();
        Vehicule Get(long id);      
        void Insert(Vehicule vehicule);
        void Update(Vehicule vehicule);
        void Delete(Vehicule vehicule);
    }
}
