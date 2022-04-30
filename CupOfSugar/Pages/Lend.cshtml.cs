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
        public JsonFileProductService ProductService { get; }  // Data middle tier

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="productService"></param>
        public LendModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public CupOfSugar.WebSite.Models.Product Product; // The data to show, bind to it for the post

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}
