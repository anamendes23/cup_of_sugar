using System;
using System.Collections.Generic;
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

        public string Lender { get; set; } //string Lender of product

        [JsonPropertyName("img")]
        public string Image { get; set; } //string url of Image of the product

        public string Title { get; set; } //string Title of product

        public string Address { get; set; } //string Adress of Lender

        public string Phone { get; set; } //string phone of Lender

        public string Quantity { get; set; } //string quantity of product

        public string Category { get; set; } // string category of product

        public string Status { get; set; } // string status of product

        /// <summary>
        /// Returns string representation of product object
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
