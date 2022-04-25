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

        public string Maker { get; set; } //string Maker of product

        [JsonPropertyName("img")]
        public string Image { get; set; } //string url of Image of the product

        public string Url { get; set; } //string Url to the product

        public string Title { get; set; } //string Title of product

        public string Description { get; set; } //string Description of product

        public int[] Ratings { get; set; } //integer array of ratings of product

        /// <summary>
        /// Returns string representation of product object
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
