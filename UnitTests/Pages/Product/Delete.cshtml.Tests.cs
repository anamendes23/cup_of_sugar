using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CupOfSugar.Pages.Product;
using CupOfSugar.WebSite.Models;

namespace UnitTests.Pages.Product
{
    /// <summary>
    ///  Unit tests class for Read page
    /// </summary>
    public class Delete
    {
        #region TestSetup
        public static DeleteModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("avaadams-avocado");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Avocado", pageModel.Product.Title);
        }
        #endregion OnGet

        #region OnPostAsync
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData();
            pageModel.Product.Title = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Borrow"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
            {
                Id = "bogus",
                Title = "bogus",
                Lender = "bogus",
                Address = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}
