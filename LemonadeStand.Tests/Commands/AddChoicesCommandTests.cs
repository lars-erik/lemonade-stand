using LemonadeStand.Common;
using LemonadeStand.Common.Commands;
using NUnit.Framework;

namespace LemonadeStand.Tests.Commands
{
    [TestFixture]
    public class AddChoicesCommandTests : GameCommandTestBase
    {
        [Test]
        public void Execute_AddsChoices()
        {
            Game.AddDay();

            var command = new AddChoicesCommand(Repository);
            var choices = new Choices(10, 9, 1);
            command.Execute(
                new AddChoices(
                    Game.Id, 
                    choices
                )
            );

            Assert.AreSame(choices, Game.CurrentDay.Choices[0]);
        }
    }
}
