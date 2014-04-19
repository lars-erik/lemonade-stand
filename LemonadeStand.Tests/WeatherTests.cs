using System;
using LemonadeStand.Common;
using NUnit.Framework;

namespace LemonadeStand.Tests
{
    [TestFixture]
    public class WeatherTests
    {
        [TearDown]
        public void TearDown()
        {
            Rnd.Reset();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void Create_WhenDayOneAndTwo_IsSunny(int day)
        {
            var weather = Weather.Create(day);
            Assert.AreEqual(Weather.Sunny, weather);
        }

        [Test]
        [TestCase(1)] // .24
        [TestCase(3)] // .29
        [TestCase(15)] // .56
        public void Create_DayN_WhenRandomLessThan6_ReturnsSunny(int seed)
        {
            AssertSeededWeather(seed, Weather.Sunny);
        }

        [Test]
        [TestCase(2)] // .77
        [TestCase(17)] // .60
        [TestCase(19)] // .65
        public void Create_DayN_WhenRandomBetween6And8_ReturnsCloudy(int seed)
        {
            AssertSeededWeather(seed, Weather.Cloudy);
        }

        [Test]
        [TestCase(4)] // .81
        [TestCase(8)] // .90
        [TestCase(10)] // .95
        public void Create_DayN_WhenRandomAboveEight_ReturnsHotAndDry(int seed)
        {
            AssertSeededWeather(seed, Weather.HotAndDry);
        }

        [Test]
        public void RandomSeed_FirstDouble_Write()
        {
            for(var seed = 1; seed<20; seed++)
            { 
                Rnd.Reset(seed);
                Console.WriteLine("{0,-3}:{1}", seed, Rnd.NextDouble());
            }
        }

        private static void AssertSeededWeather(int seed, Weather expectedWeather)
        {
            Rnd.Reset(seed);
            var weather = Weather.Create(3);
            Assert.AreEqual(expectedWeather, weather);
        }
    }
}
