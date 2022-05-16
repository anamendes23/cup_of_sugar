using CupOfSugar.Pages;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit tests for borrow/index page
    /// </summary>
    public class Borrow
    {
        #region TestSetup


        // Instance of LendModel
        public static BorrowModel pageModel;

        /// <summary>
        /// Initializing method that creates an 
        /// object of the BorrowModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new BorrowModel(TestHelper.ProductService) { };
        }

        #endregion

        #region OnGet

        /// <summary>
        /// The unit test to check if the correct 
        /// HTTP request ID is being retrieved
        /// And also check if its valid or not
        /// And also check if all the products are retrieved
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet

    }
}