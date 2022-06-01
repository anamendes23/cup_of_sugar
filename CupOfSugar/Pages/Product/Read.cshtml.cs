using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CupOfSugar.WebSite.Services;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CupOfSugar.Pages.Product
{
    /// <summary>
    /// Read Page
    /// </summary>
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public WebSite.Models.Product Product { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The borrower's name must not be null!")]
        [StringLength(1000, ErrorMessage = "The name must not be too long")]
        public string borrower { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a number greater than 0!")]
        [Range(1, Int32.MaxValue, ErrorMessage = "The number must be greater than 0!")]
        public int quantity { get; set; }


        // The status that indicate if the borrow button was clicked or not
        public bool borrowBtnStatus;
        // The value of the borrow button press
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
            if (Product.Phone.Length == 10)
            {
                return Convert.ToInt64(Product.Phone).ToString("(###) ###-####");
            }
            return Product.Phone;
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the Borrow page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Product.Names == null)
            {
                Product.Names = new List<String>();
                Product.BorrowQuantities = new List<int>();
            }

            if (quantity > Product.Quantity)
            {
                Product.BorrowQuantities.Add(Product.Quantity);
                Product.Quantity -= Product.Quantity;
            }
            else
            {
                Product.BorrowQuantities.Add(quantity);
                Product.Quantity -= quantity;
            }

            Product.Names.Add(borrower);

            if (Product.Quantity == 0)
            {
                Product.Status = "Pending";
            }

            ProductService.UpdateData(Product);
            
            return RedirectToPage("./Read");
        }
    }
}