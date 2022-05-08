using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CupOfSugar.WebSite.Models
{
    /// <summary>
    /// Product class
    /// Product model, specifies the attributes of a product
    /// </summary>
    public class Product
    {

        public string Id { get; set; } //string Id of product

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Lender { get; set; } //string Lender of product

        [JsonPropertyName("img")]
        [Required]
        public string Image { get; set; } //string url of Image of the product

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; } //string Title of product

        [Required]
        public string Address { get; set; } //string Adress of Lender

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Required]
        public string Phone { get; set; } //string phone of Lender

        [Required]
        public string Quantity { get; set; } //string quantity of product

        [Required]
        public string Category { get; set; } // string category of product

        public string Status { get; set; } // string status of product

        /// <summary>
        /// Returns string representation of product object
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
