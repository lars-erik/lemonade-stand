using LemonadeStand.Common;
using LemonadeStand.Common.RandomEvents;
using NUnit.Framework;

namespace LemonadeStand.Tests.RandomEvents
{
    [TestFixture]
    public class StormTests
    {
        [Test]
        public void ForecastMessage_IsRain()
        {
            Rnd.Reset(1);
            var storm = new Storm();
            Assert.AreEqual("There is a 42 % chance of light rain, and the weather is cooler today", storm.ForecastMessage);
        }

        [Test]
        public void ResultMessage_IsStorm()
        {
            var storm = new Storm();
            Assert.AreEqual("WEATHER REPORT: A severe thunderstorm hit lemonsville earlier today, just as the lemonade stands were being set up. Unfortunately, everything was ruined!!", storm.ResultMessage);
        }

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        public void Modify_ReturnsZero(int glassesMade)
        {
            var storm = new Storm();
            Assert.AreEqual(0, storm.Modify(glassesMade, new Choices(glassesMade, 1, 1)));
        }
    }
}
