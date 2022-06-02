namespace UnitTests
{
    public class AccountHandler
    {

        private const int discountBasic = 0;
        private const int discountGold = 30;
        private const int discountPlatinum = 50;

        private readonly ILevelChecker levelChecker;

        public AccountHandler(ILevelChecker levelChecker)
        {
            this.levelChecker = levelChecker;
        }


        public int GiveDiscount(Account account)
        {
            if (levelChecker.CheckLevel(account) == CustomerLevel.Basic)
            {
                return discountBasic;
            }
            if (levelChecker.CheckLevel(account) == CustomerLevel.Gold)
            {
                return discountGold;
            }

            return discountPlatinum;
        }

        public int HowManyPointsToNextLevel(Account account)
        {
            if (levelChecker.CheckLevel(account) == CustomerLevel.Basic)
            {
                return levelChecker.Gold - account.PointBalance;
            }
            if (levelChecker.CheckLevel(account) == CustomerLevel.Gold)
            {
                return levelChecker.Platinum - account.PointBalance;
            }

            return 0;
        }
    }
}
