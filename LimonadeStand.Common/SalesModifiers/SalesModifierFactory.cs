namespace LimonadeStand.Common.SalesModifiers
{
    public class SalesModifierFactory
    {
        public static SalesModifier Create(Weather weather)
        {
            if (weather == Weather.Cloudy)
                return new Rain();
            if (weather == Weather.HotAndDry)
                return new HeatWave();
            if (Rnd.NextDouble() < .25)
                return new StreetWork();
            return new NormalDay();
        }
    }
}
