using System;

namespace LimonadeStand.Common
{
    public static class Rnd
    {
        private static Random rnd = new Random();

        public static double NextDouble()
        {
            return rnd.NextDouble();
        }

        public static void Reset()
        {
            rnd = new Random();
        }

        public static void Reset(int seed)
        {
            rnd = new Random(seed);
        }
    }
}