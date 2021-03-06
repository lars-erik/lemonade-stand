﻿using System;
using System.Collections.Generic;
using LemonadeStand.Common.RandomEvents;

namespace LemonadeStand.Common
{
    public class Day
    {
        public const int SignPrice = 15;

        public int Number { get; private set; }
        public Weather Weather { get; private set; }
        public RandomEvent Event { get; private set; }
        public List<Choices> Choices { get; private set; } 
        public List<Result> Results { get; private set; }
        public int LemonadeCost { get; private set; }

        private Day(int number, Weather weather, RandomEvent randomEvent)
        {
            Number = number;
            Weather = weather;
            Event = randomEvent;
            Choices = new List<Choices>();
            Results = new List<Result>();
            LemonadeCost = number < 3 ? 2 : number < 5 ? 4 : 5;
        }

        public static Day Create(int dayNumber)
        {
            var weather = Weather.Create(dayNumber);
            var randomEvent = RandomEventFactory.Create(dayNumber, weather);
            return new Day(dayNumber, weather, randomEvent);
        }

        public void Calculate(int playerIndex)
        {
            var choices = Choices[playerIndex];
            var sales = Calculation.CalculateSales(choices, Event);
            var glassesSold = Math.Min(sales, choices.Glasses);
            var revenue = glassesSold*choices.Price;
            var expenses = choices.Glasses*LemonadeCost + choices.Signs*SignPrice;
            var profit = revenue - expenses;
            Results.Add(new Result(glassesSold, revenue, expenses, profit));
        }
    }
}
