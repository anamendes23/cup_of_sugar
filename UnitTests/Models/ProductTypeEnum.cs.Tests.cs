using NUnit.Framework;
using CupOfSugar.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    class ProductTypeEnumTests
    {
        [Test]
        public void DisplayName_Should_Return_Valid_String()
        {
            // Arrange

            // Act
            string fruit = ProductTypeEnum.Fruit.DisplayName();
            string vegetable = ProductTypeEnum.Vegetable.DisplayName();
            string poultry = ProductTypeEnum.Poultry.DisplayName();
            string meat = ProductTypeEnum.Meat.DisplayName();
            string dairy = ProductTypeEnum.Dairy.DisplayName();
            string entree = ProductTypeEnum.Entree.DisplayName();
            string savory = ProductTypeEnum.Savory.DisplayName();
            string dessert = ProductTypeEnum.Dessert.DisplayName();
            string drink = ProductTypeEnum.Drink.DisplayName();
            string miscellaneous = ProductTypeEnum.Miscellaneous.DisplayName();

            // Assert
            Assert.AreEqual("Fruit", fruit);
            Assert.AreEqual("Vegetable", vegetable);
            Assert.AreEqual("Poultry", poultry);
            Assert.AreEqual("Meat", meat);
            Assert.AreEqual("Dairy", dairy);
            Assert.AreEqual("Entree", entree);
            Assert.AreEqual("Savory", savory);
            Assert.AreEqual("Dessert", dessert);
            Assert.AreEqual("Drink", drink);
            Assert.AreEqual("Miscellaneous", miscellaneous);
        }
    }
}
