namespace LimonadeStand.Common
{
    public class Result
    {
        public int GlassesSold { get; private set; }
        public int Revenue { get; private set; }
        public int Expenses { get; private set; }
        public int Profits { get; private set; }

        public Result(int glassesSold, int revenue, int expenses, int profits)
        {
            GlassesSold = glassesSold;
            Revenue = revenue;
            Expenses = expenses;
            Profits = profits;
        }
    }
}