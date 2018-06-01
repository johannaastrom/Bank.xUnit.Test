using System;
using Xunit;
using Bank.xUnit;

namespace Bank.xUnit.Test
{
	public class BankTest
	{
		[Fact] //Balance method
		public void ShouldIncrementBalance()
		{
			Account account = new Account(20.00/*, 1.34*/);

			double deposit = 5.00;
			account.Deposit(deposit);
			double actualBalance = account.Balance;
			double expectedBalance = 25.00;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact] //Balance method
		public void ShouldThrowIfAmountIsUnderLimit()
		{
			Account account = new Account(20.00/*, 1.34*/);

			Assert.Throws<Exception>(() =>
			{
				account.Deposit(-1);
			});
		}

		[Fact] //Balance method
		public void ShouldThrowIfAmountIsOverLimit()
		{
			Account account = new Account(20.00/*, 1.34*/);

			Assert.Throws<Exception>(() =>
			{
				account.Deposit(50000);
			});
		}

		[Fact] //Withdraw method
		public void ShouldWithdrawAmountIfValid()
		{
			Account account = new Account(100/*, 1.34*/);

			double amount = 50;
			account.Withdraw(amount);
			double actualBalance = account.Balance;
			double expectedBalance = 50;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact] //Withdraw method
		public void ShouldThrowIfUnavailableFunds()
		{
			Account account = new Account(0/*, 1.34*/);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw(70);
			});
		}

		[Fact] //Withdraw method
		public void ShouldThrowIfOverLimit()
		{
			Account account = new Account(500/*, 1.34*/);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw(6000);
			});
		}

		[Fact] //Withdraw method
		public void ShouldThrowIfWithdrawAmountIsMinus()
		{
			Account account = new Account(100/*, 1.34*/);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw(-1);
			});
		}

		[Fact] //Transfer method
		public void ShouldTransferToSavingsIfSuccessful()
		{
			Account account = new Account(500/*, 1.34*/);
			Account savingsAccount = new Account(1000/*, 1.34*/);

			double amount = 100;
			account.Transfer(savingsAccount, amount);
			double actualBalance = savingsAccount.Balance;
			double expectedBalance = 1100;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact] //Transfer method
		public void ShouldWithdrawFromAccountIfSuccessful()
		{
			Account account = new Account(500/*, 1.34*/);
			Account savingsAccount = new Account(1000/*, 1.34*/);

			double amount = 100;
			account.Transfer(savingsAccount, amount);
			double actualBalance = account.Balance;
			double expectedBalance = 400;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact] //Transfer method
		public void ShouldThrowIfAmountToTransferIsMinus()
		{
			Account account = new Account(0/*, 1.34*/);
			Account savingsAccount = new Account(50/*, 1.34*/);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(savingsAccount, -1);
			});
		}

		[Fact]
		public void ShouldThrowIfTransferingToSameAccount()
		{
			Account account = new Account(50/*, 1.34*/);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(account, 5);
			});
		}
	}
}
