using LimonadeStand.Common;
using LimonadeStand.Common.SalesModifiers;
using NUnit.Framework;

namespace LimonadeStand.Tests.SalesModifiers
{
    [TestFixture]
    public class SalesModifierFactoryTests
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
            AssertSunnyDay<NormalDay>(seed);
        }

        private void AssertSunnyDay<TRandomEvent>(int seed)
            where TRandomEvent : SalesModifier
        {
            Rnd.Reset(seed);
            AssertWeatherEvent<TRandomEvent>(Weather.Sunny);
        }

        private static void AssertWeatherEvent<TRandomEvent>(Weather weather) 
            where TRandomEvent : SalesModifier
        {
            var evt = SalesModifierFactory.Create(weather);
            Assert.IsInstanceOf<TRandomEvent>(evt);
        }
    }
}
