using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using CupOfSugar.Pages;

namespace UnitTests.Pages.AboutUs
{
    /// <summary>
    /// Unit tests class for About Us page
    /// </summary>
    public class AboutUsTests
    {
        #region TestSetup

        public static AboutUsModel pageModel;

        /// <summary>
        /// Initializes an object of the IndexModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AboutUsModel>>();

            pageModel = new AboutUsModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Unit test to check if the About Us page is being rendered correctly
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}