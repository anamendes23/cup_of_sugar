using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CupOfSugar.WebSite.Services;

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
        /// <param name="productService"></param>
        public LendModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public CupOfSugar.WebSite.Models.Product Product { get; set; } 

        /// <summary>
        /// REST Get request
        /// Loads the data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet()
        {
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

            Product = ProductService.CreateData(Product);

            return RedirectToPage("../Index");
        }
    }
}