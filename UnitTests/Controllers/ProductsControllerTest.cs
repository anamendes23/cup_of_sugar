using NUnit.Framework;
using CupOfSugar.WebSite.Controllers;

namespace UnitTests.Controllers
{
    class ProductsControllerTest
    {
        #region TestSetup

        // Instance of LendModel
        public static ProductsController pageModel;

        /// <summary>
        /// Initializing method that creates an 
        /// object of the LendModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProductsController(TestHelper.ProductService){ };
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

            // Act
            pageModel.Get();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet
    }
}
