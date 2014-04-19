using System;
using System.Collections.Generic;
using System.Linq;

namespace LemonadeStand.Common
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public List<Day> Days { get; set; }
        public Day CurrentDay { get { return Days.LastOrDefault(); } }
        public Guid Id { get; private set; }

        public Game(Guid id)
        {
            Id = id;
            Players = new List<Player>();
            Days = new List<Day>();
        }

        public void Calculate()
        {
            var day = CurrentDay;
            for (var playerIndex = 0; playerIndex < Players.Count; playerIndex++)
            {
                day.Calculate(playerIndex);
                Players[playerIndex].Assets += day.Results[playerIndex].Profits;
            }
        }

        public void AddDay()
        {
            Days.Add(Day.Create(NextDayNumber()));
        }

        private int NextDayNumber()
        {
            return CurrentDay == null ? 1 : CurrentDay.Number + 1;
        }
    }
}
