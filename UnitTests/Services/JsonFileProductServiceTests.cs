
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using CupOfSugar.Pages;
using CupOfSugar.WebSite.Models;
using System.Linq;
using System;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region UpdateData

        [Test]
        public void UpdateData_Valid_Product_Should_Return_Updated_Product()
        {
            // Arrange
            var productData = TestHelper.ProductService.CreateData();
            var updateLenderString = "Test Lender";
            productData.Lender = updateLenderString;

            // Act
            var result = TestHelper.ProductService.UpdateData(productData);
            var testLender = TestHelper.ProductService.GetProducts().First(x => x.Id == productData.Id).Lender;

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(productData.Id, result.Id);
            Assert.AreEqual(testLender, updateLenderString);
        }

        [Test]
        public void UpdateData_InValid_Product_Should_Return_Null()
        {
            // Arrange
            CupOfSugar.WebSite.Models.Product newProductNotInJsonFile = new CupOfSugar.WebSite.Models.Product();
            newProductNotInJsonFile.Id = "95";

            // Act
            var result = TestHelper.ProductService.UpdateData(newProductNotInJsonFile);

            // Assert
            Assert.AreEqual(null, result);
        }

        #endregion UpdateData
    }
}
