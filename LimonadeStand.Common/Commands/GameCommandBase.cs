using LimonadeStand.Common.Persistence;

namespace LimonadeStand.Common.Commands
{
    public class GameCommandBase
    {
        protected IRepository<Game> Repository;
        protected Game Game;

        public GameCommandBase(IRepository<Game> repository)
        {
            Repository = repository;
        }

        protected void Initialize(GameId gameId)
        {
            Game = Repository.Get(g => g.Id == gameId.Id);
        }
    }
}