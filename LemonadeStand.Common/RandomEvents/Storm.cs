namespace LemonadeStand.Common.RandomEvents
{
    public class Storm : Rain
    {
        public override string ResultMessage
        {
            get { return "WEATHER REPORT: A severe thunderstorm hit lemonsville earlier today, just as the lemonade stands were being set up. Unfortunately, everything was ruined!!"; }
        }

        public override double Modify(double baseSales, Choices choices)
        {
            return 0;
        }

        public Storm()
            : base("Storm")
        {
            
        }
    }
}
