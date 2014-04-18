using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimonadeStand.Common;
using LimonadeStand.Common.RandomEvents;
using NUnit.Framework;

namespace LimonadeStand.Tests.RandomEvents
{
    [TestFixture]
    public class EventFactoryTests
    {
        [Test]
        public void Create_WhenCloudy_HasChanceOfRain()
        {
            AssertWeatherEvent<Rain>(Weather.Cloudy);
        }

        [Test]
        public void Create_WhenHotAndDry_IsHeatWave()
        {
            AssertWeatherEvent<HeatWave>(Weather.HotAndDry);
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
            AssertSunnyDay<JustAnotherDay>(seed);
        }

        private void AssertSunnyDay<TRandomEvent>(int seed)
            where TRandomEvent : RandomEvent
        {
            Rnd.Reset(seed);
            AssertWeatherEvent<TRandomEvent>(Weather.Sunny);
        }

        private static void AssertWeatherEvent<TRandomEvent>(Weather weather) 
            where TRandomEvent : RandomEvent
        {
            var evt = EventFactory.Create(weather);
            Assert.IsInstanceOf<TRandomEvent>(evt);
        }
    }
}
