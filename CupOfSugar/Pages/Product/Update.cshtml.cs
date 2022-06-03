using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CupOfSugar.WebSite.Services;
using System.Net;

namespace CupOfSugar.Pages.Product
{
    /// <summary>
    /// Update page
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public WebSite.Models.Product Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            
        }
        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the Index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Test img url, set to default img if does not return an img
            HttpWebRequest request;
            bool exists;

            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(Product.Image);
                request.Method = "HEAD";
                request.GetResponse();
                exists = true;
            }
            catch
            {
                exists = false;
            }

            if (exists == false)
            {
                Product.Image = "../../images/default-" + Product.Category.ToLower() + ".png"; // Set Image to default if entered url invalid
            }

            if (Product.Quantity > 0)
                Product.Status = "Available";
            ProductService.UpdateData(Product);

            return RedirectToPage("./Borrow");
        }
    }
}