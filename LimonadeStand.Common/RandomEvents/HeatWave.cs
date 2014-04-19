namespace LimonadeStand.Common.RandomEvents
{
    public class HeatWave : RandomEvent
    {
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