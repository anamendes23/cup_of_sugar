using System.Linq;

using NUnit.Framework;

using CupOfSugar.Pages.Product;
using CupOfSugar.Pages;

namespace UnitTests.Pages.Product
{
    public class LendTests
    {
        #region TestSetup
        public static LendModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LendModel(TestHelper.ProductService)
        {
        };
    }

    #endregion TestSetup

    #region OnGet
    [Test]
    public void OnGet_Valid_Should_Return_Products()
    {
        // Arrange
        var oldCount = TestHelper.ProductService.GetProducts().Count();

        // Act
        pageModel.OnGet();

        // Assert
        Assert.AreEqual(true, pageModel.ModelState.IsValid);
        Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetProducts().Count());
    }
    #endregion OnGet
    }
}