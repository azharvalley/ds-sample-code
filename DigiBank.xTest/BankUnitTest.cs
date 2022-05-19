using BankyStuffLibrary;
using System;
using Xunit;

namespace DigiBank.xTest
{
    public class BankUnitTest
    {
        [Fact]
        public void TrueIsTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void CanTakeMoreThanYouHave()
        {
            var account = new BankAccount("Sam", 1000);
            // Test for a negative balance
            Assert.Throws<InvalidOperationException>(
                () => account.MakeWithdrawal(75000, 
                DateTime.Now,
                "Attempt to overdraw")
                );
        }

        [Fact]
        public void NeedMoneyToStart()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BankAccount(
                    "Peter",
                    -55)
                );
        }
    }
}
