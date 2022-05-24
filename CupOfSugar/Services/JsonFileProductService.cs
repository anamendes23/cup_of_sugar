using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CupOfSugar.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace CupOfSugar.WebSite.Services
{
    /// <summary>
    /// JsonFileProductService
    /// Accesses, adds and modifies products in Products.json
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// JsonFileProductService constructor
        /// Initializes the webHostEnvironment object
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; } //Provides info about application's webhosting env

        /// <summary>
        /// method that returns the path of the products.json file
        /// </summary>
        private string JsonFileName
        {
            //returns path string
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); } 
        }

        /// <summary>
        /// Gets all products from Products.json
        /// </summary>
        /// <returns>IEnumerable list of products</returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                //converts into a list of products
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public Product UpdateData(Product data)
        {
            var products = GetProducts();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            productData.Lender = data.Lender;
            productData.Image = data.Image;
            productData.Title = data.Title;
            productData.Address = data.Address;
            productData.Phone = data.Phone;
            productData.Quantity = data.Quantity;
            productData.Category = data.Category;
            productData.Status = data.Status;
            productData.Unit = data.Unit;
            productData.Names = data.Names;
            productData.BorrowQuantities = data.BorrowQuantities;
            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<Product> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public Product CreateData()
        {
            var data = new Product()
            {
                Id = System.Guid.NewGuid().ToString(),
                Lender = "",
                Image = "",
                Title = "",
                Address = "",
                Phone = "",
                Quantity = 0,
                Category = "",
                Status = "Available",
                Unit = "Unit",
                Names = { },
                BorrowQuantities = { }
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetProducts();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Create a new product using the passed values
        /// </summary>
        /// <returns></returns>
        public Product CreateData(Product data)
        {
            data.Id = System.Guid.NewGuid().ToString();
            data.Status = "Available";

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetProducts();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public Product DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetProducts();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetProducts().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }
    }
}