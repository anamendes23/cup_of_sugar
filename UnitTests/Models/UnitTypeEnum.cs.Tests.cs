using NUnit.Framework;
using CupOfSugar.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit tests for ProductTypeEnum
    /// </summary>
    class UnitTypeEnumTests
    {
        #region DisplayName

        /// <summary>
        /// Tests that DisplayName returns valid string for 
        /// Enum value
        /// </summary>
        [Test]
        public void DisplayName_Should_Return_Valid_String()
        {
            // Arrange

            // Act
            string unit = UnitTypeEnum.Unit.DisplayName();
            string ounce = UnitTypeEnum.Ounce.DisplayName();
            string pound = UnitTypeEnum.Pound.DisplayName();
            string cup = UnitTypeEnum.Cup.DisplayName();
            string bag = UnitTypeEnum.Bag.DisplayName();
            string box = UnitTypeEnum.Box.DisplayName();
            string slice = UnitTypeEnum.Slice.DisplayName();
            string loaf = UnitTypeEnum.Loaf.DisplayName();
            string bottle = UnitTypeEnum.Bottle.DisplayName();
            string can = UnitTypeEnum.Can.DisplayName();

            // Assert
            Assert.AreEqual("unit(s)", unit);
            Assert.AreEqual("oz(s)", ounce);
            Assert.AreEqual("lb(s)", pound);
            Assert.AreEqual("cup(s)", cup);
            Assert.AreEqual("bag(s)", bag);
            Assert.AreEqual("box(es)", box);
            Assert.AreEqual("slice(s)", slice);
            Assert.AreEqual("loaf/loaves", loaf);
            Assert.AreEqual("bottle(s)", bottle);
            Assert.AreEqual("can(s)", can);
        }

        #endregion DisplayName
    }
}
