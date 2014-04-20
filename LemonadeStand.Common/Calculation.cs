using System;
using LemonadeStand.Common.RandomEvents;

namespace LemonadeStand.Common
{
    public class Calculation
    {
        private const double HighPrice = 10;
        private const double Demand = 30;

        public static double SalesFactor(int pricePerGlass)
        {
            if (pricePerGlass < HighPrice)
                return (HighPrice - pricePerGlass)/HighPrice*.8*Demand + Demand;
            return Math.Pow(HighPrice, 2)*Demand/Math.Pow(pricePerGlass, 2);
        }

        public static double SignFactor(int signs)
        {
            return 1 - Math.Exp(-signs*.5);
        }

        public static double BaseSales(Choices choices)
        {
            var salesFactor = SalesFactor(choices.Price);
            var signFactor = SignFactor(choices.Signs);
            return salesFactor + (salesFactor*signFactor);
        }

        public static int CalculateSales(Choices choices, RandomEvent randomEvent)
        {
            var glassesSold = BaseSales(choices);
            glassesSold = randomEvent.Modify(glassesSold, choices);
            return (int) Math.Floor(glassesSold);
        }
    }
}
