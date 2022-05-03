using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CupOfSugar.WebSite.Models;
using CupOfSugar.WebSite.Services;

namespace CupOfSugar.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show// The data to show, bind to it for the post
        [BindProperty]
        public WebSite.Models.Product Product { get; set; }

        public bool borrowBtnStatus;
        public string borrowBtnValue;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            if (Product.Status == "Available")
            {
                borrowBtnStatus = false;
                borrowBtnValue = "Borrow";
            }
            else
            {
                borrowBtnStatus = true;
                borrowBtnValue = "Pending";
            }
        }

        /// <summary>
        /// Helper function that formats the stored phone number
        /// </summary>
        /// <returns>Formatted phone number</returns>
        public string GetFormattedPhone()
        {
            return Convert.ToInt64(Product.Phone).ToString("(###) ###-####");
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the read page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            Product.Status = "Pending";

            ProductService.UpdateData(Product);

            return RedirectToPage("../Index");
        }
    }
}
