using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CupOfSugar.Pages
{
    /// <summary>
    /// Arielle Wilson
    /// </summary>
    /// <summary>
    /// Ana Carolina de Souza Mendes
    /// </summary>
    /// <summary>
    /// Phuc To
    /// </summary>
    /// <summary>
    /// Ananya Reddy
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
