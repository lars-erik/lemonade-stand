using LemonadeStand.Common;
using LemonadeStand.Common.RandomEvents;
using NUnit.Framework;

namespace LemonadeStand.Tests.RandomEvents
{
    [TestFixture]
    public class StreetWorkTests
    {
        private StreetWork streetWork;

        [Test]
        public void ForecastMessage_ReturnsStreetWorkMessage()
        {
            Assert.AreEqual("The street department is working today. There will be no traffic on your street.", new StreetWork().ForecastMessage);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ResultMessage_WhenNotThirsty_ReturnsBlank(int seed)
        {
            Setup(seed);
            Assert.AreEqual("", streetWork.ResultMessage);
        }

        [Test]
        [TestCase(1)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(18)]
        public void ResultMessage_WhenThirsty_DrankAllYourLemonade(int seed)
        {
            Setup(seed);
            Assert.AreEqual("The street crews bought all your lemonade at lunchtime!!", streetWork.ResultMessage);
        }

        [Test]
        [TestCase(2, 10)]
        [TestCase(2, 100)]
        [TestCase(3, 10)]
        [TestCase(3, 100)]
        [TestCase(4, 10)]
        [TestCase(4, 100)]
        public void Modify_WhenNotThirsty_IsZero(int seed, int glassesMade)
        {
            Setup(seed);
            Assert.AreEqual(0, streetWork.Modify(glassesMade, new Choices(glassesMade, 9, 10)));
        }

        [Test]
        [TestCase(1, 10, 10)]
        [TestCase(1, 100, 100)]
        [TestCase(14, 10, 10)]
        [TestCase(14, 100, 100)]
        [TestCase(16, 10, 10)]
        [TestCase(16, 100, 100)]
        [TestCase(18, 10, 10)]
        [TestCase(18, 100, 100)]
        public void Modify_WhenThirsty_DrinksAll(int seed, int glassesMade, int expectedSales)
        {
            Setup(seed);
            Assert.AreEqual(expectedSales, streetWork.Modify(glassesMade, new Choices(glassesMade, 9, 10)));
        }

        private void Setup(int seed)
        {
            Rnd.Reset(seed);
            streetWork = new StreetWork();
        }
    }
}
