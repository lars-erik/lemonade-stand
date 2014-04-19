using System;
using LimonadeStand.Common.Persistence;

namespace LimonadeStand.Common.Commands
{
    public class CreateGameCommand
    {
        private readonly IRepository<Game> repository;

        public CreateGameCommand(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        public CreateGameResult Execute(CreateGame createGame)
        {
            var id = Guid.NewGuid();
            var game = new Game(id);
            foreach (var playerName in createGame.PlayerNames)
                game.Players.Add(new Player(playerName));
            repository.Insert(game);
            return new CreateGameResult(id);
        }
    }

    public class CreateGame
    {
        public CreateGame(string[] playerNames)
        {
            PlayerNames = playerNames;
        }

        public string[] PlayerNames { get; private set; }
    }

    public class CreateGameResult
    {
        public Guid Id { get; set; }

        public CreateGameResult(Guid id)
        {
            Id = id;
        }
    }
}
