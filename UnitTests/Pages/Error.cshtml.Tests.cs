using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using CupOfSugar.Pages;

namespace UnitTests.Pages.Error
{
    /// <summary>
    /// Unit test for Error page
    /// </summary>
    public class ErrorTests
    {
        #region TestSetup
        public static ErrorModel pageModel;
        /// <summary>
        /// Initializing method that creates an object of the ErrorModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            pageModel = new ErrorModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// The Unit test case to check if the correct HTTP request ID is being retrieved
        /// And also check if its valid or not
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, pageModel.RequestId);
        }

        /// <summary>
        /// The Unit test case to check if the correct HTTP request ID is being retrieved
        /// And also check if its invalid, meaning null
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("trace", pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);
        }
        #endregion OnGet
    }
}