using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CupOfSugar.WebSite.Services;
using CupOfSugar.WebSite.Models;

namespace CupOfSugar.Pages
{
    /// <summary>
    /// LendModel class
    /// Will be developed further to Lend page - Create in CRUDi associated with Lend form
    /// </summary>
    public class LendModel : PageModel
    {
        public JsonFileProductService ProductService { get; }

        public LendModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }
    }
}
