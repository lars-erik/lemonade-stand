using System;
using System.Reflection;

namespace LimonadeStand.Common
{
    public class Weather
    {
        private readonly string name;
        public static readonly Weather Sunny = new Weather("Sunny");
        public static readonly Weather Cloudy = new Weather("Cloudy");
        public static readonly Weather HotAndDry = new Weather("HotAndDry");

        private Weather(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return name;
        }

        public static Weather Create(int day)
        {
            if (day < 3)
                return Sunny;
            var value = Rnd.NextDouble();
            if (value < .6) return Sunny;
            if (value < .8) return Cloudy;
            return HotAndDry;
        }
    }
}
