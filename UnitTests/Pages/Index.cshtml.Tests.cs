using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using CupOfSugar.Pages;

namespace UnitTests.Pages.Index
{
    /// <summary>
    /// Unit tests class for Index page
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        public static IndexModel pageModel;

        /// <summary>
        /// Initializes an object of the IndexModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Unit test to check if the Index page is being rendered correctly
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
    }
}