using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.MockRepositories;

namespace Repositories.Tests
{
    [TestClass]
    public class ModelRepositoryTests
    {
        // c'est possible d'utiliser le package Moq, mais vue on a deja ces repo mocker donc on peux les utilisees
        private IModelRepository _vehiculeModelsRepository = new MockVehiculeModelRepository();

        [TestMethod]
        public void GetAll_Test()
        {
           var result = _vehiculeModelsRepository.GetAll();
           Assert.IsTrue(result.Count == 4);
        }

        [TestMethod]
        public void Get_Test()
        {
            var result = _vehiculeModelsRepository.Get(3);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete_Test()
        {
            var nombreModelAvant = 4;
            _vehiculeModelsRepository.Delete(new ModelVehicule(){Id = 3});
            Assert.IsTrue(_vehiculeModelsRepository.GetAll().Count == nombreModelAvant -1);
        }
        [TestMethod]
        public void Update_Test()
        {
            _vehiculeModelsRepository.Update(new ModelVehicule(){Id = 3, Model = "newName"});
            Assert.IsTrue(_vehiculeModelsRepository.Get(3).Model == "newName");
        }
    }
}
