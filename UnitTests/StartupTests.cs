using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

using NUnit.Framework;

namespace UnitTests.Pages.Startup
{
    /// <summary>
    /// Tests for the Startup.cs page defined in this class
    /// </summary>
    public class StartupTests
    {
        #region TestSetup

     
        [SetUp]
        public void TestInitialize()
        {
        }

        public class Startup : CupOfSugar.WebSite.Startup
        {
            /// <summary>
            /// Constructor to Startup 
            /// </summary>
            /// <param name="config"></param>
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        #region ConfigureServices

        /// <summary>
        /// Unit test to verify if the services are working 
        /// </summary>
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        #region Configure

        /// <summary>
        /// Unit test to verify if the website is building correctly
        /// </summary>
        [Test]
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }

        #endregion Configure
    }
}