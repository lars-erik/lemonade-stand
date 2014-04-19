using System;
using LimonadeStand.Common;
using LimonadeStand.Tests.Fakes;
using NUnit.Framework;

namespace LimonadeStand.Tests.Commands
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