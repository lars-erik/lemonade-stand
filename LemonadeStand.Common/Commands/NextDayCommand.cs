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
        public int Number { get; set; }
        public Weather Weather { get; set; }
        public string ForecastMessage { get; set; }
        public int LemonadeCost { get; set; }

        public NextDayResult(Day day)
        {
            Number = day.Number;
            Weather = day.Weather;
            ForecastMessage = day.Event.ForecastMessage;
            LemonadeCost = day.LemonadeCost;
        }
    }
}
