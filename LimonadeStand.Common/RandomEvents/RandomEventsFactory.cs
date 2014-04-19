namespace LimonadeStand.Common.RandomEvents
{
    public class RandomEventFactory
    {
        public static RandomEvent Create(Weather weather)
        {
            if (weather == Weather.Cloudy)
                return CloudyEvent();
    
            if (weather == Weather.HotAndDry)
                return HotAndDryEvent();
            
            return SunnyEvent();
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

        private static RandomEvent SunnyEvent()
        {
            if (Rnd.NextDouble() < .25)
                return new StreetWork();
            return new NormalDay();
        }
    }
}
