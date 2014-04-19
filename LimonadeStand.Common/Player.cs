namespace LimonadeStand.Common
{
    public class Player
    {
        private const int StartingAssets = 200;
        public string Name { get; set; }
        public int Assets { get; set; }

        public Player(string name)
        {
            Name = name;
            Assets = StartingAssets;
        }
    }
}
