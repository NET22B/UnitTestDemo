namespace UnitTests
{
    public class LevelChecker : ILevelChecker
    {
        private const int gold = 50;
        private const int platinum = 200;

        public int Gold => gold;
        public int Platinum { get { return platinum; } }

        public CustomerLevel CheckLevel(Account account)
        {
            if (account.PointBalance < gold)
            {
                return CustomerLevel.Basic;
            }
            if (account.PointBalance < platinum)
            {
                return CustomerLevel.Gold;
            }
            else
            {
                return CustomerLevel.Platinum;
            }
        }
    }
}
