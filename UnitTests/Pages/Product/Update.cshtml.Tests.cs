using System.Linq;

using NUnit.Framework;

using CupOfSugar.Pages.Product;
using CupOfSugar.Pages;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit test for Lend page
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel; // Instance of LendModel

        /// <summary>
        /// Initializing method that creates an object of the LendModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
        {
        };
    }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// The Unit test case to check if the correct HTTP request ID is being retrieved
        /// And also check if its valid or not
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Product()
        {
            // Arrange

            // Act
            pageModel.OnGet("mary-banana");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Bananas", pageModel.Product.Title);
        }

        #endregion OnGet

        #region OnPost

        /// <summary>
        /// The Unit test case to check if a Product is returned 
        /// When form is posted, and redirect to correct page
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
            {
                Id = "mary-banana",
                Lender = "bogus",
                Image = "bogus",
                Title = "bogus",
                Address = "bogus",
                Phone = "bogus",
                Quantity = 0,
                Category = "bogus",
                Status = "bogus"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Borrow"));
        }

        /// <summary>
        /// The Unit test case to check if an invalid Lendmodel
        /// Causes a invalid return page
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product()
            {
                Id = "bogus",
                Lender = "bogus",
                Image = "bogus",
                Title = "bogus",
                Address = "bogus",
                Phone = "bogus",
                Quantity = 0,
                Category = "bogus",
                Status = "bogus"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPost
    }
}