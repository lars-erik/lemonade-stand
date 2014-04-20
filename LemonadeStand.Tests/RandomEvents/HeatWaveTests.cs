using LemonadeStand.Common;
using LemonadeStand.Common.RandomEvents;
using NUnit.Framework;

namespace LemonadeStand.Tests.RandomEvents
{
    [TestFixture]
    public class HeatWaveTests
    {
        [Test]
        public void ForecastMessage_ReturnsTheresAHeatWaveToday()
        {
            Assert.AreEqual("There's a heat wave predicted today.", new HeatWave().ForecastMessage);
        }

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void Modify_GivesDoubleSales(int glassesMade)
        {
            Assert.AreEqual(glassesMade*2, new HeatWave().Modify(glassesMade, new Choices(glassesMade, 100, 0)));
        }
    }
}
