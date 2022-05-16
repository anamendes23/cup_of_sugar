using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CupOfSugar.WebSite
{
    /// <summary>
    /// Program class
    /// Builds project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// starts the website
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Returns the startup type to be used by the webhost
        /// </summary>
        /// <param name="args"></param>
        /// <returns>startup type</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}