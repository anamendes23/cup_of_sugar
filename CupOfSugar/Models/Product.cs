using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CupOfSugar.WebSite.Models
{
    /// <summary>
    /// Product class
    /// Product model, specifies the attributes of a product
    /// </summary>
    public class Product
    {
        public string Id { get; set; } //string Id of product

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(60, MinimumLength = 3)]
        public string Lender { get; set; } //string Lender of product

        [Required(ErrorMessage = "Please enter an image URL.")]
        [Url(ErrorMessage = "Please enter a valid image URL")]
        [JsonPropertyName("img")]
        public string Image { get; set; } //string url of Image of the product

        [Required(ErrorMessage = "Please enter a title between 3 and 60 characters.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Please enter a title between 3 and 60 characters.")]
        public string Title { get; set; } //string Title of product

        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; } //string Adress of Lender

        [Required(ErrorMessage = "Please enter a 10 digit phone number.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", 
            ErrorMessage = "Not a valid phone number. Please enter a 10 digit phone number.")]
        public string Phone { get; set; } //string phone of Lender

        [Required(ErrorMessage = "Please enter a quantity greater than 0.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter a quantity greater than 0.")]
        public int Quantity { get; set; } //int quantity of product

        [Required(ErrorMessage = "Please select a unit from the list. " +
            "Select 'Unit' if not known.")]
        public string Unit { get; set; } // string unit of product

        [Required(ErrorMessage = "Please select a category from the list. " +
            "Select 'Miscellaneous' if not known.")]
        public string Category { get; set; } // string category of product

        public string Status { get; set; } // string status of product

        public List<string> Names { get; set; } // string names of people borrowing product

        public List<int> BorrowQuantities { get; set; } // int quantities that people are borrowing

        /// <summary>
        /// Returns string representation of product object
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}