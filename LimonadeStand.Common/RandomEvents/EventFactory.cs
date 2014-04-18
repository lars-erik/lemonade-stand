namespace LimonadeStand.Common.RandomEvents
{
    public class EventFactory
    {
        public static RandomEvent Create(Weather weather)
        {
            if (weather == Weather.Cloudy)
                return new Rain();
            if (weather == Weather.HotAndDry)
                return new HeatWave();
            if (Rnd.NextDouble() < .25)
                return new StreetWork();
            return new JustAnotherDay();
        }
    }
}
