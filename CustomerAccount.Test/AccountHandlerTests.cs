

using Moq;
using UnitTests;
using Xunit;

namespace CustomerAccount.Test
{
    public class AccountHandlerTests
    {
        [Fact]
        public void GiveDiscount_BasicCustomer()
        {
            var account = new Account("Test Testberg", 10);

            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Basic);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);

            var expected = 0;
            var actual = accountHandler.GiveDiscount(account);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GiveDiscount_GoldCustomer()
        {
            var account = new Account("Test Testberg", 60);

            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Gold);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);

            var expected = 30;
            var actual = accountHandler.GiveDiscount(account);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void HowManyPointsToNextLevel_BasicCustomer()
        {
            // Arrange
            var account = new Account("Test Testsjö", 0);
            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Basic);
            mockLevelChecker.Setup(x => x.Gold).Returns(50);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);

            // Act
            var expected = 50;
            int actual = accountHandler.HowManyPointsToNextLevel(account);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HowManyPointsToNextLevel_GoldCustomer()
        {
            // Arrange
            var account = new Account("Test Testsjö", 50);
            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Gold);
            mockLevelChecker.Setup(x => x.Platinum).Returns(200);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);

            // Act
            var expected = 150;
            int actual = accountHandler.HowManyPointsToNextLevel(account);

            // Assert
            Assert.Equal(expected, actual);
        }



    }
}
