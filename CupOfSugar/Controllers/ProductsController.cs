using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CupOfSugar.WebSite.Services;
using CupOfSugar.WebSite.Models;

namespace CupOfSugar.WebSite.Controllers
{
    /// <summary>
    /// ProductsController
    /// Deals with CRUDi requests made to website
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Constructor to the ProductsController class
        /// It initializes the productService object
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
  
        public JsonFileProductService ProductService { get; } // ProductService attribute deals with json file

        /// <summary>
        ///This is the Read method in CRUDi 
        ///Uses HttpGet to get all the products
        /// </summary>
        /// <returns>List of all products</returns>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
    }
}