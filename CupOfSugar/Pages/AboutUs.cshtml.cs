using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CupOfSugar.Pages
{
    public class AboutUsModel : PageModel
    {
        private readonly ILogger<AboutUsModel> _logger; //readonly ILogger object that allows logging

        /// <summary>
        /// AboutUsModel constructor
        /// initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public AboutUsModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// placeholder for OnGet method
        /// </summary>
        public void OnGet()
        {
        }
    }
}