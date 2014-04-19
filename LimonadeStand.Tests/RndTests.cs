using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimonadeStand.Common;
using NUnit.Framework;

namespace LimonadeStand.Tests
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
