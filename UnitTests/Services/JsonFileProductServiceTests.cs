using NUnit.Framework;
using System.Linq;

namespace UnitTests.Pages.Product.AddRating
{
    /// <summary>
    /// JsonFileProductServiceTests unit test class
    /// with tests for the JsonFileProductService
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        /// <summary>
        /// Initialize test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region UpdateData

        /// <summary>
        /// Test that passes if UpdateData returns an updated product 
        /// when a valid product is passed to this method.
        /// Returned Updated object should have same fields as valid
        /// object passed to UpdateData.
        /// </summary>
        [Test]
        public void UpdateData_Valid_Product_Should_Return_Updated_Product()
        {
            // Arrange
            var productData = TestHelper.ProductService.CreateData(); // Create new product
            var updateLenderString = "Test Lender"; 
            productData.Lender = updateLenderString; // Set new product to have lender of "Test Lender"

            // Act
            var result = TestHelper.ProductService.UpdateData(productData);
            var testLender = TestHelper.ProductService.GetProducts().First(x => x.Id == productData.Id).Lender;

            // Assert
            Assert.AreNotEqual(null, result); // Updated object should not be null
            Assert.AreEqual(productData.Id, result.Id); // Passed in object and updted object should have equal Ids
            Assert.AreEqual(testLender, updateLenderString); // Updated object Lender should equal "Test lender" 
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

        #region CreateData

        /// <summary>
        /// Passes if CreateData method successfully creates a 
        /// non-null Product
        /// </summary>
        [Test]
        public void CreateData_Valid_Product_Should_Return_New_Product()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.CreateData();

            // Assert
            Assert.AreNotEqual(null, result);
        }

        #endregion CreateData
     }
}