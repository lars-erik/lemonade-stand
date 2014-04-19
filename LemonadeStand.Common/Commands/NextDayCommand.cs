using LemonadeStand.Common.Persistence;

namespace LemonadeStand.Common.Commands
{
    public class NextDayCommand : GameCommandBase
    {
        public NextDayCommand(IRepository<Game> repository)
            : base(repository)
        {
        }

        public NextDayResult Execute(GameId gameId)
        {
            Initialize(gameId);
            Game.AddDay();
            return new NextDayResult(Game.CurrentDay);
        }
    }

    public class NextDayResult
    {
        public Weather Weather { get; set; }
        public string ForecastMessage { get; set; }

        public NextDayResult(Day day)
        {
            Weather = day.Weather;
            ForecastMessage = day.Event.ForecastMessage;
        }
    }
}
