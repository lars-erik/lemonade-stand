namespace LimonadeStand.Common.RandomEvents
{
    public class NormalDay : RandomEvent
    {
        public override double Modify(double baseSales, Choices choices)
        {
            return baseSales;
        }
    }
}