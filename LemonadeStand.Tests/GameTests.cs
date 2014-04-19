using System;
using LemonadeStand.Common;
using NUnit.Framework;

namespace LemonadeStand.Tests
{
    [TestFixture]
    public class GameTests
    {
        // TODO: Serialization tests?

        [Test]
        public void AddDay_AddsNextDay()
        {
            var game = new Game(Guid.NewGuid());
            game.AddDay();
            game.AddDay();
            Assert.AreEqual(2, game.CurrentDay.Number);
        }

        [Test]
        public void AcceptanceTest()
        {
            Rnd.Reset(1);

            var game = new Game(Guid.NewGuid());
            game.Players.Add(new Player("Player 1"));
            game.Players.Add(new Player("Player 2"));

            game.AddDay();
            game.CurrentDay.Choices.Add(new Choices(10, 9, 1));
            game.CurrentDay.Choices.Add(new Choices(20, 5, 2));
            game.Calculate();

            Assert.AreEqual(255, game.Players[0].Assets);
            Assert.AreEqual(230, game.Players[1].Assets);

            game.AddDay();
            game.CurrentDay.Choices.Add(new Choices(5, 5, 3));
            game.CurrentDay.Choices.Add(new Choices(25, 6, 1));
            game.Calculate();

            Assert.AreEqual(225, game.Players[0].Assets);
            Assert.AreEqual(315, game.Players[1].Assets);
        }
    }
}
