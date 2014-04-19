﻿using LimonadeStand.Common.Commands;
using NUnit.Framework;

namespace LimonadeStand.Tests.Commands
{
    [TestFixture]
    public class NextDayCommandTests : GameCommandTestBase
    {
        [Test]
        public void Execute_CreatesDay_ReturnsWeather()
        {
            var command = new NextDayCommand(Repository);
            var result = command.Execute(new GameId(Game.Id));
            Assert.AreEqual(Game.CurrentDay.Weather, result.Weather);
            Assert.AreEqual(Game.CurrentDay.Event.ForecastMessage, result.ForecastMessage);
        }
    }
}
