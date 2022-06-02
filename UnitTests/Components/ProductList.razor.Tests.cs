using Bunit;
using NUnit.Framework;
using CupOfSugar.Components;
using Microsoft.Extensions.DependencyInjection;
using CupOfSugar.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// setup unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        /// Tests that the default page has content
        /// Including the bananas food item
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Bananas"));
        }

        #region ClearFilterData

        /// <summary>
        /// Tests that clicking the clear button resets the
        /// Fiter to an empty string
        /// </summary>
        [Test]
        public void ClearFilterData_Should_Set_Filter_Input_To_Empty_String()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains("Clear"));

            // Fing all input elements
            var inputList = page.FindAll("input");

            // Find the input element with id filter-input
            var filterInput = inputList.First(m => m.Id.Equals("filter-input"));

            // Act
            button.Click();

            //Assert
            Assert.AreEqual("", filterInput.InnerHtml);
        }

        #endregion ClearFilterData

        #region EnableFilterData

        /// <summary>
        /// Tests that enabling filter data allows filtering and 
        /// rendering of content
        /// </summary>
        [Test]
        public void EnableFilterData_Should_return_Content()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains("Filter"));

            // Find input elements
            var inputList = page.FindAll("input");

            // Find the input element with id filter-input
            var filterInput = inputList.First(m => m.Id.Equals("filter-input"));

            // Set the value of this input to Avocado
            filterInput.InnerHtml = "Avocado";

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Avocado"));
        }

        #endregion EnableFilterData

        #region UpdateFilterCategory

        /// <summary>
        /// Tests that changing the cateogry filter dropdown 
        /// returns content
        /// </summary>
        [Test]
        public void UpdateFilterCategory_Should_return_Content()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var categoryDropdown = page.Find("select");

            // Act
            categoryDropdown.Change("Fruit");

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Avocado"));
        }

        #endregion UpdateFilterCategory

        #region UpdateFilterText

        /// <summary>
        /// Tests that updating the filter text to a valid query
        /// will return content
        /// </summary>
        [Test]
        public void updateFilterText_Should_Return_Content()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains("Filter"));

            // Find all input elements
            var inputList = page.FindAll("input");

            // Find input element with id filter-input 
            var filterInput = inputList.First(m => m.Id.Equals("filter-input"));

            // Act
            filterInput.Change("Avocado");
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Avocado"));
        }

        #endregion UpdateFilterText

        #region MovetoRead

        /// <summary>
        /// Tests that clicking more info on a product redirects 
        /// to th eRead page for that product
        /// </summary>
        [Test]
        public void MovetoRead_Should_Redirect_To_Read_Page()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();
            
            // Id of Avocado lender
            var id = "avaadams-avocado";

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Create a NavigationManager
            var nav = Services.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();

            // Act 
            button.Click();
           
            // Assert
            Assert.AreEqual("http://localhost/Product/Read/" + id, nav.Uri);
        }

        #endregion MovetoRead 

        #region EnableAvailabilityFilter

        /// <summary>
        /// Tests that available products are listed when 
        /// availability filter is checked (true).
        /// </summary>
        [Test]
        public void EnableAvailabilityFilter_True_Should_Return_Available_Products()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Get all inputs
            var inputList = page.FindAll("input");

            // Get checkbox (input with id of availability)
            var checkbox = inputList.First(m => m.Id.Equals("availability"));

            // Act
            // Check the availability box
            checkbox.Change(true);

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Avocado"));
        }

        /// <summary>
        /// Tests that when the availability filter is not checked
        /// Pending items are rendered.
        /// </summary>
        [Test]
        public void EnableAvailabilityFilter_False_Should_Return_All_Products()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Get all inputs
            var inputList = page.FindAll("input");

            // Get checkbox (input with id of availability)
            var checkbox = inputList.First(m => m.Id.Equals("availability"));

            // Act
            // Check and then uncheck the box for availability
            checkbox.Change(true);
            checkbox.Change(false);

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            // Unicorn Cupcake has a Pending status
            Assert.AreEqual(true, pageMarkup.Contains("Cupcake"));
        }

        #endregion EnableAvailabilityFilter

        #region FilterAndRenderProducts

        /// <summary>
        /// Tests that filtering for an item when its incorrect category
        /// is selected returns "Sorry! Could not find any items matching 
        /// your search." Message
        /// </summary>
        [Test]
        public void Filter_For_Non_Existing_Products_Should_Return_No_Matching_Products_Message()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var categoryDropdown = page.Find("select");

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");
            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains("Filter"));

            // Find all input elements
            var inputList = page.FindAll("input");
            // Find input element with id filter-input 
            var filterInput = inputList.First(m => m.Id.Equals("filter-input"));

            // Act
            // Change cateory to fruit
            categoryDropdown.Change("Fruit");
            // Search for a non-fruit item, a dessert that does not exist in fruit category
            filterInput.Change("Macarons");
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Sorry! Could not find any items matching your search."));
        }

        #endregion FilterAndRenderProducts
    }
}