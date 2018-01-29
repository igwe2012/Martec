using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Martec.Domain.Managers;
using Martec.Infrastruture.DataEntities;
using Martec.Domain.Interfaces;
using Martec.Infrastruture.Repositories;
using System.Web.Configuration;

namespace Martec.Tests.Managers
{
    [TestClass]
    public class ProductManagerTest
    {
        [TestMethod]
        public void GetInventory()
        {
            //Arrange
            var repo = new ProductRepository(new MartecEntities());
            var manager = new ProductManager(repo);

            //Act
            var product = manager.GetInventory();

            //Asserts
            Assert.IsTrue(product != null, "the product is null");
        }
    }
}
