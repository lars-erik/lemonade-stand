using LemonadeStand.Common;
using LemonadeStand.Common.Commands;
using NUnit.Framework;

namespace LemonadeStand.Tests.Commands
{
    [TestFixture]
    public class FinishDayCommandTests : GameCommandTestBase
    {
        [Test]
        public void Execute_Calculates_ReturnsResults()
        {
            Game.AddDay();
            
            Game.Players.Add(new Player("1"));
            Game.Players.Add(new Player("2"));
            Game.CurrentDay.Choices.Add(new Choices(10, 9, 1));
            Game.CurrentDay.Choices.Add(new Choices(5, 5, 2));

            var command = new FinishDayCommand(Repository);
            var results = command.Execute(new GameId(Game.Id));

            Assert.AreSame(Game.CurrentDay.Results, results.Results);
        }

        [Test]
        public void Execute_ReturnsEventResultMessage()
        {
            Game.AddDay();
            Game.AddDay();

            Rnd.Reset(25);
            Game.AddDay();

            var command = new FinishDayCommand(Repository);
            var result = command.Execute(new GameId(Game.Id));

            Assert.IsTrue(result.ResultMessage.StartsWith("WEATHER REPORT: A severe thunderstorm"));
        }
    }
}
