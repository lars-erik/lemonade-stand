namespace LemonadeStand.Common
{
    public class Choices
    {
        public Choices(int glasses, int price, int signs)
        {
            Glasses = glasses;
            Price = price;
            Signs = signs;
        }

        public Choices()
        {
        }

        public int Glasses { get; set; }
        public int Price { get; set; }
        public int Signs { get; set; }
    }
}