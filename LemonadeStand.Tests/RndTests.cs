using System;
using LemonadeStand.Common;
using NUnit.Framework;

namespace LemonadeStand.Tests
{
    [TestFixture]
    public class RndTests
    {
        [Test]
        public void NextDouble_Table()
        {
            for (var seed = 1; seed <= 25; seed++)
            {
                Rnd.Reset(seed);
                Console.WriteLine("{0,-2}: {1,-5:n2} {2,-5:n2}", seed, Rnd.NextDouble(), Rnd.NextDouble());
            }
        }
    }
}
