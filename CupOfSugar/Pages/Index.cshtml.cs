using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CupOfSugar.Pages
{
    /// <summary>
    /// IndexModel class
    /// For the index page
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger; // ILogger object for logging

        /// <summary>
        /// Constructor to the IndexModel
        /// Initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Placeholder for the OnGet method
        /// </summary>
        public void OnGet()
        {
        }
    }
}