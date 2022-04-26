using NUnit.Framework;
/// <summary>
/// sample test file for understanding unit tests
/// </summary>
namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}