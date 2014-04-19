using System.Collections.Generic;
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
            var choices = new List<Choices>
            {
                new Choices(10, 9, 1),
                new Choices(5, 5, 2),
            };
            command.Execute(
                new AddChoices(
                    Game.Id, 
                    choices
                )
            );

            Assert.AreSame(choices[0], Game.CurrentDay.Choices[0]);
            Assert.AreSame(choices[1], Game.CurrentDay.Choices[1]);
        }
    }
}
