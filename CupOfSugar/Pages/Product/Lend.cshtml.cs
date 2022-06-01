using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CupOfSugar.WebSite.Services;
using System.ComponentModel.DataAnnotations;
using System;

namespace CupOfSugar.Pages.Product
{
    /// <summary>
    /// Lend page
    /// </summary>
    public class LendModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; } 

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="productService">The service that interacts with the products.json file</param>
        public LendModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public CupOfSugar.WebSite.Models.Product Product { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter a quantity greater than 0.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter a quantity greater than 0.")]
        public int initQuantity { get; set; } //int quantity of product

        /// <summary>
        /// REST Get request
        /// Loads the data
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product.Quantity = initQuantity;
            Product = ProductService.CreateData(Product);

            return RedirectToPage("../Index");
        }
    }
}