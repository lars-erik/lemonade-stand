using LimonadeStand.Common.Persistence;

namespace LimonadeStand.Common.Commands
{
    public class NextDayCommand
    {
        private readonly IRepository<Game> repository;

        public NextDayCommand(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        public NextDayResult Execute(GameId gameId)
        {
            var game = repository.Get(g => g.Id == gameId.Id);
            game.AddDay();
            return new NextDayResult(game.CurrentDay.Weather);
        }
    }

    public class NextDayResult
    {
        public Weather Weather { get; set; }

        public NextDayResult(Weather weather)
        {
            Weather = weather;
        }
    }
}
