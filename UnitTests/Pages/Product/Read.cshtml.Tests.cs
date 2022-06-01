using NUnit.Framework;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CupOfSugar.Pages.Product;
using System.Collections.Generic;

namespace UnitTests.Pages.Product
{
    /// <summary>
    ///  Unit tests class for Read page
    /// </summary>
    public class Read
    {
        #region TestSetup
        // Instance of ReadModel
        public static ReadModel pageModel;

        /// <summary>
        /// Initializing method that creats an
        /// object of the Read Model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// The unit test to check if the correct
        /// HTTP request ID with Status: Available is being retrieved
        /// Also check if it's valid or not
        /// </summary>
        [Test]
        public void OnGet_Valid_Available_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("avaadams-avocado");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Avocado", pageModel.Product.Title);
        }

        /// <summary>
        /// The unit test to check if the correct
        /// HTTP request ID with Status: Pending 
        /// is being retrieved
        /// Also check if it's valid or not
        /// </summary>
        [Test]
        public void OnGet_Valid_Pending_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = TestHelper.ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals("avaadams-avocado"));
            pageModel.Product.Status = "Pending";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            pageModel.OnGet("avaadams-avocado");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Avocado", pageModel.Product.Title);
        }

        #endregion OnGet


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
            pageModel.OnGet("avaadams-avocado");
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
                Lender = "mary",
                Image = "https://user-images.githubusercontent.com/64483865/165871171-927f964d-e94f-4179-b90a-dde80e613e23.jpg",
                Title = "Bananas",
                Address = "212 Burley Streets Apt. 699 - 158201",
                Phone = "3409523801",
                Quantity = 8,
                Category = "Fruit",
                Status = "Pending",
                Unit = "Unit",
                Names = null,
                BorrowQuantities = null
            };
            pageModel.borrower = "Phuc";
            pageModel.quantity = 2;

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual("{\"Id\":\"mary-banana\",\"Lender\":\"mary\"," +
                            "\"img\":\"https://user-images.githubusercontent.com/64483865/165871171-927f964d-e94f-4179-b90a-dde80e613e23.jpg\"," +
                            "\"Title\":\"Bananas\",\"Address\":\"212 Burley Streets Apt. 699 - 158201\",\"Phone\":\"3409523801\",\"Quantity\":6," +
                            "\"Unit\":\"Unit\",\"Category\":\"Fruit\",\"Status\":\"Pending\",\"Names\":[\"Phuc\"],\"BorrowQuantities\":[2]}",
                            pageModel.Product.ToString());
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        [Test]
        public void OnPostAsync_Valid_All_Item_Should_Update_Status()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
            {
                Id = "mary-banana",
                Lender = "mary",
                Image = "https://user-images.githubusercontent.com/64483865/165871171-927f964d-e94f-4179-b90a-dde80e613e23.jpg",
                Title = "Bananas",
                Address = "212 Burley Streets Apt. 699 - 158201",
                Phone = "3409523801",
                Quantity = 8,
                Category = "Fruit",
                Status = "Available",
                Unit = "Unit",
                Names = null,
                BorrowQuantities = null
            };
            pageModel.borrower = "Phuc";
            pageModel.quantity = 8;

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual("Pending",
                            pageModel.Product.Status);
        }

        [Test]
        public void OnPostAsync_Too_Big_Quantity_Should_Treat_As_1()
        {
            // Arrange
            pageModel.Product = new CupOfSugar.WebSite.Models.Product
            {
                Id = "mary-banana",
                Lender = "mary",
                Image = "https://user-images.githubusercontent.com/64483865/165871171-927f964d-e94f-4179-b90a-dde80e613e23.jpg",
                Title = "Bananas",
                Address = "212 Burley Streets Apt. 699 - 158201",
                Phone = "3409523801",
                Quantity = 8,
                Category = "Fruit",
                Status = "Available",
                Unit = "Unit",
                Names = null,
                BorrowQuantities = null
            };
            pageModel.borrower = "Phuc";
            pageModel.quantity = 9;

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(0, pageModel.Product.Quantity);
            Assert.AreEqual(8, pageModel.Product.BorrowQuantities[0]);
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// The Unit test case to check if an invalid ReadModel
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
                Quantity = 0,
                Category = "bogus",
                Status = "bogus"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPost
    }
}