namespace LemonadeStand.Common.RandomEvents
{
    public class NormalDay : RandomEvent
    {
        public NormalDay() : base("Normal day")
        {
        }

        public override double Modify(double baseSales, Choices choices)
        {
            return baseSales;
        }
    }
}