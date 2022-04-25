using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        /// <summary>
        /// CRUdi - Update method
        /// This method updates the rating
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="Rating"></param>
        /// <returns>Ok Status</returns>
        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
