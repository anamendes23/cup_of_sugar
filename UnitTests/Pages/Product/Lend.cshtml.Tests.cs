using NUnit.Framework;
using CupOfSugar.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit tests for Lend page
    /// </summary>
    public class LendTests
    {
        #region TestSetup

        // Instance of LendModel
        public static LendModel pageModel;

        /// <summary>
        /// Initializing method that creates an 
        /// object of the LendModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LendModel(TestHelper.ProductService) { };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// The unit test to check if the correct 
        /// HTTP request ID is being retrieved
        /// And also check if its valid or not
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet

        #region OnPost

        /// <summary>
        /// The Unit test case to check if a 
        /// Product is returned When form is 
        /// posted, and redirects to correct page
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
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
            pageModel.initQuantity = 1;

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        /// <summary>
        /// The Unit test case to check if an 
        /// invalid Lendmodel Causes an invalid 
        /// return page
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

        /// <summary>
        /// Tests that when a valid image url is provided
        /// The product's image is NOT set to the default image
        /// </summary>
        [Test]
        public void OnPost_Given_Valid_Image_URL_Product_Image_Should_Not_Be_Set_To_Default_Image()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product()
            {
                Id = "an-id-123",
                Lender = "Sleepy Larry",
                Image = "https://user-images.githubusercontent.com/64483865/165871015-14dd3358-7188-43a5-92cd-a8e7dc336aab.jpg",
                Title = "Something Stinky",
                Address = "123 adress st WA 98276",
                Phone = "0123456789",
                Quantity = 2,
                Category = "Fruit",
                Status = "Available"
            };

            // Default image path, what a Fruit Product image is set to if its given url is invalid
            var defaultFruitImagePath = "../../images/default-" + pageModel.Product.Category.ToLower() + ".png";

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            // All attributes are valid, so the page state should be valid
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            
            // The product's given url is valid, so it should NOT be equal to the default Fruit image path
            Assert.AreNotEqual(pageModel.Product.Image, defaultFruitImagePath);
        }

        #endregion OnPost
    }
}