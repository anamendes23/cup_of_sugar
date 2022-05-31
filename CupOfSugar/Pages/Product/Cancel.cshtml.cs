using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CupOfSugar.WebSite.Services;
using System;

namespace CupOfSugar.Pages.Product
{
    /// <summary>
    /// Cancel Borrow Page
    /// </summary>
    public class CancelModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="productService"></param>
        public CancelModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public WebSite.Models.Product Product { get; set; }

        // The index of the borrow to be canceled
        public int num;

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            string[] words = id.Split('&');
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(words[0]));
            _ = Int32.TryParse(words[1], out num);
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the borrow page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(string id)
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }


            string[] words = id.Split('&');
            _ = Int32.TryParse(words[1], out int num);

            Product.Quantity += Product.BorrowQuantities[num];
            Product.Names.RemoveAt(num);
            Product.BorrowQuantities.RemoveAt(num);
            Product.Status = "Available";
            ProductService.UpdateData(Product);

            return RedirectToPage("./Borrow");

        }


        /// <summary>
        /// Helper function that formats the stored phone number
        /// </summary>
        /// <returns>Formatted phone number</returns>
        public string GetFormattedPhone()
        {
            if (Product.Phone.Length == 10)
            {
                return Convert.ToInt64(Product.Phone).ToString("(###) ###-####");
            }
            return Product.Phone;
        }
    }
}