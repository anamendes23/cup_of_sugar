using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CupOfSugar.Pages
{
    /// <summary>
    /// Error Page class
    /// Defines the errors for bad website requests
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {

        public string RequestId { get; set; } //string RequestId is the id of request object

        /// <summary>
        /// Takes RequestId as an input
        /// And returns true if it is a valid request
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger; //ILogger object for error logging

        /// <summary>
        /// Constructor to the ErrorModel
        /// Initializes the logger
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the Id of the http request
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
