namespace UnitTests
{
    public interface ILevelChecker
    {
        CustomerLevel CheckLevel(Account account);
        public int Gold { get; }
        public int Platinum { get; }
    }
}
