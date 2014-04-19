namespace LimonadeStand.Common.RandomEvents
{
    public class RandomEventFactory
    {
        public static RandomEvent Create(int day, Weather weather)
        {
            if (weather == Weather.Cloudy)
                return CloudyEvent();
    
            if (weather == Weather.HotAndDry)
                return HotAndDryEvent();
            
            return SunnyEvent(day);
        }

        private static RandomEvent CloudyEvent()
        {
            if (Rnd.NextDouble() < .25)
                return new Storm();
            return new Rain();
        }

        private static RandomEvent HotAndDryEvent()
        {
            return new HeatWave();
        }

        private static RandomEvent SunnyEvent(int day)
        {
            if (day > 2 && Rnd.NextDouble() < .25)
                return new StreetWork();
            return new NormalDay();
        }
    }
}
