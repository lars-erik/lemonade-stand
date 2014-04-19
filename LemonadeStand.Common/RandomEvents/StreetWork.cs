namespace LemonadeStand.Common.RandomEvents
{
    public class StreetWork : RandomEvent
    {
        private readonly bool boughtAll;

        public StreetWork()
            : base("Street work")
        {
            var chance = Rnd.NextDouble();
            boughtAll = chance < .25;
        }

        public override double Modify(double baseSales, Choices choices)
        {
            return boughtAll ? choices.Glasses : 0;
        }

        public override string ResultMessage
        {
            get { return boughtAll ? "The street crews bought all your lemonade at lunchtime!!" : base.ResultMessage; }
        }

        public override string ForecastMessage
        {
            get { return "The street department is working today. There will be no traffic on your street."; }
        }
    }
}