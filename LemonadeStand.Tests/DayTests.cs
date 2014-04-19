using NUnit.Framework;

namespace LemonadeStand.Tests
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

        [Test]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void LemonadeCosts_Increases(int dayNumber, int costs)
        {
            var day = Day.Create(dayNumber);
            Assert.AreEqual(costs, day.LemonadeCosts);
            // TODO: Day start event?
        }

        [Test]
        public void Calculate_CreatesResults()
        {
            var day = Day.Create(1);
            day.Choices.Add(new Choices(10, 9, 1));
            day.Calculate(0);

            Assert.AreEqual(10, day.Results[0].GlassesSold);
            Assert.AreEqual(35, day.Results[0].Expenses);
            Assert.AreEqual(55, day.Results[0].Profits);
        }

    }
}
