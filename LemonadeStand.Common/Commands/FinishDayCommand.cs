using System.Collections.Generic;
using LemonadeStand.Common.Persistence;

namespace LemonadeStand.Common.Commands
{
    public class FinishDayCommand : GameCommandBase
    {
        public FinishDayCommand(IRepository<Game> repository)
            : base(repository)
        {
        }

        public FinishDayResult Execute(GameId gameId)
        {
            Initialize(gameId);
            Game.Calculate();
            return new FinishDayResult(
                Game.CurrentDay.Event.Name,
                Game.CurrentDay.Event.ResultMessage,
                Game.CurrentDay.Results
                );
        }
    }

    public class FinishDayResult
    {
        public string ResultMessage { get; set; }
        public string EventName { get; set; }
        public List<Result> Results { get; set; }

        public FinishDayResult(string eventName, string resultMessage, List<Result> results)
        {
            EventName = eventName;
            ResultMessage = resultMessage;
            Results = results;
        }
    }
}
