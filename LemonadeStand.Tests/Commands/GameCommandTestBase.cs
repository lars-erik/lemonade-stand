using System;
using LemonadeStand.Common;
using LemonadeStand.Tests.Fakes;
using NUnit.Framework;

namespace LemonadeStand.Tests.Commands
{
    public class GameCommandTestBase
    {
        protected Game Game;
        protected FakeRepository<Game> Repository;

        [SetUp]
        public void Setup()
        {
            Game = new Game(Guid.NewGuid());
            Repository = new FakeRepository<Game>();
            Repository.Insert(Game);
        }
    }
}