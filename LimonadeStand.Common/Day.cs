using LimonadeStand.Common.RandomEvents;

namespace LimonadeStand.Common
{
    public class Day
    {
        public int Number { get; private set; }
        public Weather Weather { get; private set; }
        public RandomEvent Event { get; private set; }

        private Day(int number, Weather weather, RandomEvent randomEvent)
        {
            Number = number;
            Weather = weather;
            Event = randomEvent;
        }

        public static Day Create(int dayNumber)
        {
            var weather = Weather.Create(dayNumber);
            var randomEvent = RandomEventFactory.Create(dayNumber, weather);
            return new Day(dayNumber, weather, randomEvent);
        }
    }
}
