namespace LimonadeStand.Common.RandomEvents
{
    public abstract class RandomEvent
    {
        public string Name { get; private set; }
        public abstract double Modify(double baseSales, Choices choices);

        public virtual string ForecastMessage 
        {
            get { return ""; }
        }

        public virtual string ResultMessage 
        {
            get { return ""; }
        }

        protected RandomEvent(string name)
        {
            Name = name;
        }
    }
}