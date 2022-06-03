using NUnit.Framework;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CupOfSugar.Pages.Product;

namespace UnitTests.Pages.Products
{
    /// <summary>
    ///  Unit tests class for Confirm Pickup page
    /// </summary>
    public class ConfirmBorrow
    {
        #region TestSetup

        // Instance of Confirm Pickup Model
        public static ConfirmPickupModel pageModel;

        /// <summary>
        /// Initializing method that creates an 
        /// object of the ConfirmPickupModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ConfirmPickupModel(TestHelper.ProductService) { };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// The unit test to check if the Model state is valid or not
        /// If the product title matches the product for the provided ID
        /// And if the page model number is not null
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Be_Valid_State_And_Valid_Borrow_Index()
        {
            // Arrange

            // Act
            pageModel.OnGet("avaadams-avocado&0");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Avocado", pageModel.Product.Title);
            Assert.NotNull(pageModel.num);
        }
        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// The Unit test case to check if a 
        /// Product is returned When form is 
        /// posted, and redirects to correct page
        /// </summary>
        [Test]
        public void OnPostAsync_Zeroed_Item_Should_Update_Status()
        {
            // Arrange

            // First Create the product to delete

            pageModel.Product = TestHelper.ProductService.GetProducts().FirstOrDefault(x => (x.Names.Count == 1 && x.Quantity == 0));
            var productId = pageModel.Product.Id;
            var id = pageModel.Product.Id + "&" + "0";

            // Act
            var result = pageModel.OnPost(id) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Borrow"));

            // Confirm the borrower is deleted
            var newStatus = TestHelper.ProductService.GetProducts().FirstOrDefault(x => x.Id.Equals(productId)).Status;
            Assert.AreEqual("Out of Stock", newStatus);
        }

        /// <summary>
        /// The Unit test case to check if a 
        /// Product is returned When form is 
        /// posted, and redirects to correct page
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete

            pageModel.Product = TestHelper.ProductService.GetProducts().FirstOrDefault(x => x.Names.Count > 0);
            var id = pageModel.Product.Id + "&" + "0";
            var borrowerCount = pageModel.Product.Names.Count;

            // Act
            var result = pageModel.OnPost(id) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Borrow"));

            // Confirm the borrower is deleted
            var newBorrowerCount = TestHelper.ProductService.GetProducts().FirstOrDefault(x => x.Id.Equals(pageModel.Product.Id)).Names.Count;
            Assert.AreEqual(borrowerCount - 1, newBorrowerCount);
        }

        /// <summary>
        /// The Unit test case to check if the page model
        /// is invalid for a bogus product
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
            {
                Id = "bogus",
                Title = "bogus",
                Lender = "bogus",
                Address = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost(pageModel.Product.Id) as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync

        #region GetFormattedPhone

        /// <summary>
        /// The unit test to check if the 
        /// valid phone number of the item 
        /// is formatted correctly
        /// </summary>
        [Test]
        public void GetFormattedPhone_Valid_Should_Return_Formatted_Phone()
        {
            // Arrange

            // Act
            pageModel.OnGet("avaadams-avocado&0");
            string formattedPhone = pageModel.GetFormattedPhone();
            // Assert
            Assert.AreEqual("(783) 549-6521", formattedPhone);
        }

        /// <summary>
        /// The unit test to check if the 
        /// invalid phone number of the item 
        /// is left unformatted
        /// </summary>
        [Test]
        public void GetFormattedPhone_Invalid_Should_Return_Unformatted_Phone()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
            {
                Id = "mary-banana",
                Lender = "bogus",
                Image = "bogus",
                Title = "bogus",
                Address = "bogus",
                Phone = "549-6521",
                Quantity = 0,
                Category = "bogus",
                Status = "bogus"
            };

            // Act
            string formattedPhone = pageModel.GetFormattedPhone();

            // Assert
            Assert.AreEqual("549-6521", formattedPhone);
        }
        #endregion GetFormattedPhone
    }
}