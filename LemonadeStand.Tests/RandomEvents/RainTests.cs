using System;
using LemonadeStand.Common;
using LemonadeStand.Common.RandomEvents;
using NUnit.Framework;

namespace LemonadeStand.Tests.RandomEvents
{
    [TestFixture]
    public class RainTests
    {
        [Test]
        [TestCase(1, .42)]
        [TestCase(2, .69)]
        [TestCase(3, .45)]
        public void ForecastMessage_IsChanceOfRain(int seed, double expectedChance)
        {
            Rnd.Reset(seed);
            var expectedMessage = String.Format("There is a {0:p0} chance of light rain, and the weather is cooler today", expectedChance);
            var rain = new Rain();
            Assert.AreEqual(expectedMessage, rain.ForecastMessage);
        }

        [Test]
        [TestCase(1, 57)]
        [TestCase(2, 31)]
        [TestCase(3, 55)]
        public void Modify_MultipliesByOneMinusChanceOfRain(int seed, int expectedValue)
        {
            Rnd.Reset(seed);
            var rain = new Rain();
            Assert.AreEqual(expectedValue, rain.Modify(100, new Choices()));
        }
    }
}
