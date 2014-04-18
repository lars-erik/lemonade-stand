namespace LimonadeStand.Common
{
    public class Weather
    {
        public static readonly Weather Sunny = new Weather();

        private Weather()
        {
            
        }

        public static Weather Create(int day)
        {
            return Sunny;
        }
    }
}
