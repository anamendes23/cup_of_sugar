using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CupOfSugar.Pages.Product;

namespace UnitTests.Pages.Product
{
    /// <summary>
    ///  Unit tests class for Read page
    /// </summary>
    public class Read
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("avaadams-avocado");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Avocado", pageModel.Product.Title);
        }
        #endregion OnGet


        #region GetFormattedPhone
        [Test]
        public void GetFormattedPhone_Valid_Should_Return_Formatted_Phone()
        {
            // Arrange

            // Act
            pageModel.OnGet("avaadams-avocado");
            string formattedPhone = pageModel.GetFormattedPhone();
            // Assert
            Assert.AreEqual("(783) 549-6521", formattedPhone);
        }
        #endregion GetFormattedPhone

        #region OnPost
        /// <summary>
        /// The Unit test case to check if a Product is returned 
        /// When form is posted, and redirect to correct page
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
            {
                Id = "mary-banana",
                Lender = "bogus",
                Image = "bogus",
                Title = "bogus",
                Address = "bogus",
                Phone = "bogus",
                Quantity = "bogus",
                Category = "bogus",
                Status = "bogus"
            };

            // Act
            var result = pageModel.OnPost("mary-banana") as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        /// <summary>
        /// The Unit test case to check if an invalid Lendmodel
        /// Causes a invalid return page
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product()
            {
                Id = "bogus",
                Lender = "bogus",
                Image = "bogus",
                Title = "bogus",
                Address = "bogus",
                Phone = "bogus",
                Quantity = "bogus",
                Category = "bogus",
                Status = "bogus"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost("mary-banana") as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPost
    }
}
