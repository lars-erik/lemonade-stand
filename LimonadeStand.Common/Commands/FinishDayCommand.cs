using System.Collections.Generic;
using LimonadeStand.Common.Persistence;

namespace LimonadeStand.Common.Commands
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
                Game.CurrentDay.Event.ResultMessage,
                Game.CurrentDay.Results
                );
        }
    }

    public class FinishDayResult
    {
        public string ResultMessage { get; set; }
        public List<Result> Results { get; set; }

        public FinishDayResult(string resultMessage, List<Result> results)
        {
            ResultMessage = resultMessage;
            Results = results;
        }
    }
}
