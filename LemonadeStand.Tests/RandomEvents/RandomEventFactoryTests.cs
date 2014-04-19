using LemonadeStand.Common;
using LemonadeStand.Common.RandomEvents;
using NUnit.Framework;

namespace LemonadeStand.Tests.RandomEvents
{
    [TestFixture]
    public class RandomEventFactoryTests
    {
        [Test]
        public void Create_WhenCloudy_HasChanceOfRain()
        {
            AssertSeededEvent<Rain>(1, Weather.Cloudy);
        }

        [Test]
        public void Create_WhenCloudyAndRandomLessThanTwentyFive_IsStorm()
        {
            AssertSeededEvent<Storm>(14, Weather.Cloudy);
        }

        [Test]
        public void Create_WhenHotAndDry_IsHeatWave()
        {
            AssertWeatherEvent<HeatWave>(Weather.HotAndDry);
        }

        [Test]
        [TestCase(1)] // .24
        [TestCase(14)] // .4
        public void Create_WhenSunny_DayLessThan3IsNormal(int seed)
        {
            Rnd.Reset(seed);
            var evt = RandomEventFactory.Create(2, Weather.Sunny);
            Assert.IsInstanceOf<NormalDay>(evt);
        }

        [Test]
        [TestCase(1)] // .24
        [TestCase(14)] // .4
        public void Create_WhenSunny_Has25PercentChanceOfStreetWork(int seed)
        {
            AssertSunnyDay<StreetWork>(seed);
        }

        [Test]
        [TestCase(2)] // .77
        [TestCase(3)] // .29
        public void Create_WhenSunny_Has75PercentChanceOfJustAnotherDay(int seed)
        {
            AssertSunnyDay<NormalDay>(seed);
        }

        private void AssertSunnyDay<TRandomEvent>(int seed)
            where TRandomEvent : RandomEvent
        {
            AssertSeededEvent<TRandomEvent>(seed, Weather.Sunny);
        }

        private static void AssertSeededEvent<TRandomEvent>(int seed, Weather weather) 
            where TRandomEvent : RandomEvent
        {
            Rnd.Reset(seed);
            AssertWeatherEvent<TRandomEvent>(weather);
        }

        private static void AssertWeatherEvent<TRandomEvent>(Weather weather) 
            where TRandomEvent : RandomEvent
        {
            var evt = RandomEventFactory.Create(3, weather);
            Assert.IsInstanceOf<TRandomEvent>(evt);
        }
    }
}
