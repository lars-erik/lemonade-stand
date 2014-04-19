using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimonadeStand.Common;
using LimonadeStand.Common.RandomEvents;
using NUnit.Framework;

namespace LimonadeStand.Tests
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        [TestCase(1, 51.6)]
        [TestCase(2, 49.2)]
        [TestCase(3, 46.8)]
        [TestCase(7, 37.2)]
        [TestCase(8, 34.8)]
        [TestCase(9, 32.4)]
        public void SalesFactor_ReturnsFormula1WhenPriceLessThanMaxPrice(int pricePerGlass, double expectedFactor)
        {
            var factor = Calculation.SalesFactor(pricePerGlass);
            Assert.AreEqual(expectedFactor, factor);
        }

        [Test]
        [TestCase(10, 30.0)]
        [TestCase(11, 24.79)]
        [TestCase(12, 20.83)]
        [TestCase(16, 11.71)]
        [TestCase(17, 10.38)]
        [TestCase(18, 9.25)]
        public void SalesFactor_ReturnsFormula2WhenPriceGreaterThanMaxPrice(int pricePerGlass, double expectedFactor)
        {
            var factor = Calculation.SalesFactor(pricePerGlass);
            Assert.AreEqual(expectedFactor, factor, .01);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, .39)]
        [TestCase(2, .63)]
        [TestCase(5, .91)]
        [TestCase(10, 1.0)]
        [TestCase(100, 1.0)]
        [TestCase(1000, 1.0)]
        public void SignFactor_ReturnsExponentialValue(int signs, double expectedFactor)
        {
            var factor = Calculation.SignFactor(signs);
            Assert.AreEqual(expectedFactor, factor, .01);
        }

        [Test]
        [TestCase(1, 0, 32.4)]
        [TestCase(10, 0, 32.4)]
        [TestCase(10, 1, 45.14)]
        [TestCase(10, 5, 62.14)]
        [TestCase(10, 10, 64.58)]
        public void Sales_ReturnsBaseSalesPlusSigns(int glasses, int signs, double expectedSales)
        {
            const int price = 9;
            var sales = Calculation.BaseSales(new Choices(glasses, price, signs));
            Assert.AreEqual(expectedSales, sales, 0.01);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0.5, 30)]
        [TestCase(1, 60)]
        public void Calculate_ModifiesUsingRandomEvent(double factor, int expectedSales)
        {
            const int glasses = 100;
            const int signs = 2;
            const int price = 7;
            var sales = Calculation.CalculateSales(new Choices(glasses, price, signs), new FakeRandomEvent(factor));
            Assert.AreEqual(expectedSales, sales);
        }

        private class FakeRandomEvent : RandomEvent
        {
            private readonly double factor;

            public FakeRandomEvent(double factor)
                : base("Fake event")
            {
                this.factor = factor;
            }

            public override double Modify(double baseSales, Choices choices)
            {
                return baseSales*factor;
            }
        }
    }
}
