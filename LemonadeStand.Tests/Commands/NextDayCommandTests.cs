using LemonadeStand.Common.Commands;
using NUnit.Framework;

namespace LemonadeStand.Tests.Commands
{
    [TestFixture]
    public class NextDayCommandTests : GameCommandTestBase
    {
        [Test]
        public void Execute_CreatesDay_ReturnsWeather()
        {
            var command = new NextDayCommand(Repository);
            var result = command.Execute(new GameId(Game.Id));
            Assert.AreEqual(Game.CurrentDay.Number, result.Number);
            Assert.AreEqual(Game.CurrentDay.LemonadeCost, result.LemonadeCost);
            Assert.AreEqual(Game.CurrentDay.Weather, result.Weather);
            Assert.AreEqual(Game.CurrentDay.Event.ForecastMessage, result.ForecastMessage);
        }
    }
}
