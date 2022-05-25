using NUnit.Framework;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CupOfSugar.Pages.Product;

namespace UnitTests.Pages.Product
{
    /// <summary>
    ///  Unit tests class for Cancel page
    /// </summary>
    public class Cancel
    {
        #region TestSetup
        public static CancelModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CancelModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
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