namespace LemonadeStand.Common.RandomEvents
{
    public class HeatWave : RandomEvent
    {
        public HeatWave() : base("Heat wave")
        {
        }

        public override string ForecastMessage
        {
            get { return "There's a heat wave predicted today."; }
        }

        public override double Modify(double baseSales, Choices choices)
        {
            return choices.Glasses;
        }
    }
}