using System;
using LimonadeStand.Common;
using LimonadeStand.Common.Commands;
using LimonadeStand.Tests.Fakes;
using NUnit.Framework;

namespace LimonadeStand.Tests.Commands
{
    [TestFixture]
    public class NextDayCommandTests
    {
        [Test]
        public void Execute_CreatesDay_ReturnsWeather()
        {
            var game = new Game(Guid.NewGuid());
            var repository = new FakeRepository<Game>();
            repository.Insert(game);

            var command = new NextDayCommand(repository);
            var result = command.Execute(new GameId(game.Id));
            Assert.AreEqual(game.CurrentDay.Weather, result.Weather);

        }
    }
}
