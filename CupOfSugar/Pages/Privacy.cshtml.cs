using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CupOfSugar.Pages
{
    /// <summary>
    /// PrivacyModel class
    /// For privacy page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger; //readonly ILogger object that allows logging

        /// <summary>
        /// PrivacyModel constructor
        /// initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
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