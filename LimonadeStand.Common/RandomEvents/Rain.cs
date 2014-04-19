using System;

namespace LimonadeStand.Common.RandomEvents
{
    public class Rain : RandomEvent
    {
        private readonly double chance;

        public Rain()
        {
            chance = .3 + Rnd.NextDouble()*.5;
        }
        
        public override double Modify(double baseSales, Choices choices)
        {
            return Math.Floor(baseSales*(1-chance));
        }

        public override string ForecastMessage 
        {
            get
            {
                return String.Format("There is a {0:p0} chance of light rain, and the weather is cooler today", chance);
            }
        }
    }
}