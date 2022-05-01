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

        [BindProperty]
        public CupOfSugar.WebSite.Models.Product Product { get; set; } // The data to show, bind to it for the post

        /// <summary>
        /// REST Get request
        /// initializes Product to new Product
        /// </summary>
        /// <param name="id"></param>
        public void OnGet()
        {
            Product = ProductService.CreateData();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.UpdateData(Product);

            return RedirectToPage("../Index");
        }
    }
}
