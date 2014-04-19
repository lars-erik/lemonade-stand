using System;
using LimonadeStand.Common.RandomEvents;

namespace LimonadeStand.Common
{
    public class Calculation
    {
        private const double HighPrice = 10;
        private const double SalesModifier = 30;

        public static double SalesFactor(int pricePerGlass)
        {
            if (pricePerGlass < HighPrice)
                return (HighPrice - pricePerGlass)/HighPrice*.8*SalesModifier + SalesModifier;
            return Math.Pow(HighPrice, 2)*SalesModifier/Math.Pow(pricePerGlass, 2);
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
