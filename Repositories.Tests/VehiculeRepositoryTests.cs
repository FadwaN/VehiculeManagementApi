using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Interfaces;
using Repositories.MockRepositories;

namespace Repositories.Tests
{
    [TestClass]
    public class VehiculeRepositoryTests
    {
        // c'est possible d'utiliser le package Moq, mais vue on a deja ces repo mocker donc on peux les utilisees
        private IVehiculeRepository _vehiculeRepository = new MockVehiculeRepository();

        [TestMethod]
        public void GetAll_Test()
        {
            var result = _vehiculeRepository.GetAll();
            Assert.IsTrue(result.Count == 4);
        }

        [TestMethod]
        public void Get_Test()
        {
            var result = _vehiculeRepository.Get(3);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete_Test()
        {
            var nombreVehiculeAvant = 4;
            _vehiculeRepository.Delete(new Vehicule() { Id = 3 });
            Assert.IsTrue(_vehiculeRepository.GetAll().Count == nombreVehiculeAvant - 1);
        }
        [TestMethod]
        public void Update_Test()
        {
            _vehiculeRepository.Update(new Vehicule() { Id = 3, Nom = "newName" });
            Assert.IsTrue(_vehiculeRepository.Get(3).Nom == "newName");
        }
    }
}
