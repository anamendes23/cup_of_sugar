using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using CupOfSugar.Pages;

namespace UnitTests.Pages.Privacy
{
    /// <summary>
    /// Unit tests class for Privacy page
    /// </summary>
    public class PrivacyTests
    {
        #region TestSetup
        public static PrivacyModel pageModel;

        /// <summary>
        /// Initializes an object of the PrivacyModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();

            pageModel = new PrivacyModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Unit test to check if the Privacy page is being rendered correctly
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet
    }
}