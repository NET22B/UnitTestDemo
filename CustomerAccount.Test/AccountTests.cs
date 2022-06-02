
using System;
using UnitTests;
using Xunit;

namespace CustomerAccount.Test
{
    public class AccountTests
    {
        [Fact]
        public void SpendMoney_AmountIsLessThanZero_Throws()
        {
            // Arrange
            var startingBalance = 0;
            var spendingAmount = -100.0;
            var account = new Account("Test Testdahl", startingBalance);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.SpendMoney(spendingAmount));
        }

        [Fact]
        public void SpendPoints_AmountIsLessThanBalance_Throws()
        {
            // Arrange
            var startingBalance = 10;
            var spendingAmount = 20;
            var account = new Account("Test Testdahl", startingBalance);
            var expected = "Amount of points spent is more than current point balance. (Parameter 'nrOfPoints')";


            // Act
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => account.SpendPoints(spendingAmount));
            var actual = error.Message;

            // Assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void SpendPoints_ReducePointBalance()
        {
            // Arrange
            var startingBalance = 10;
            var spendingAmount = 5;
            var expected = 5;
            var account = new Account("Test Testdahl", startingBalance);

            // Act
            account.SpendPoints(spendingAmount);
            var actual = account.PointBalance;

            // Assert
            Assert.Equal(expected, actual);
        }

        //[Theory]
        //[InlineData(1,2,3)]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //public void TaBort()
        //{

        //}
    }
}