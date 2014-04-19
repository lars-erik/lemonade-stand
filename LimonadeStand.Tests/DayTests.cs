using LimonadeStand.Common;
using NUnit.Framework;

namespace LimonadeStand.Tests
{
    [TestFixture]
    public class DayTests
    {
        [Test]
        [TestCase(1, 1, "Sunny", "Normal day")]
        [TestCase(2, 1, "Sunny", "Normal day")]
        [TestCase(3, 1, "Sunny", "Street work")]
        [TestCase(3, 2, "Cloudy", "Rain")]
        [TestCase(3, 4, "HotAndDry", "Heat wave")]
        [TestCase(3, 25, "Cloudy", "Storm")]
        public void Create_CreatesWeatherAndEvent(int dayNumber, int seed, string weather, string randomEvent)
        {
            Rnd.Reset(seed);
            var day = Day.Create(dayNumber);
            Assert.AreEqual(dayNumber, day.Number);
            Assert.AreEqual(weather, day.Weather.Name);
            Assert.AreEqual(randomEvent, day.Event.Name);
        }
    }
}
