using System;
using System.Reflection;

namespace LimonadeStand.Common
{
    public class Weather
    {
        public static readonly Weather Sunny = new Weather();
        public static readonly Weather Cloudy = new Weather();
        public static readonly Weather HotAndDry = new Weather();

        private Weather()
        {
            
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
