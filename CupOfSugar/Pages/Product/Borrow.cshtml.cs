using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using CupOfSugar.WebSite.Services;

namespace CupOfSugar.Pages
{
    /// <summary>
    /// Borrow (Index) page
    /// Will use get method to retrieve the food items
    /// </summary>
    public class BorrowModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public BorrowModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data Service
        public JsonFileProductService ProductService { get; }

        // Collection of the Data
        public IEnumerable<CupOfSugar.WebSite.Models.Product> Products { get; private set; }

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
