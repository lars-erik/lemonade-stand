using LimonadeStand.Common;
using NUnit.Framework;

namespace LimonadeStand.Tests
{
    [TestFixture]
    public class WeatherTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void Create_WhenDayOneAndTwo_IsSunny(int day)
        {
            var weather = Weather.Create(day);
            Assert.AreEqual(Weather.Sunny, weather);
        }
    }
}
