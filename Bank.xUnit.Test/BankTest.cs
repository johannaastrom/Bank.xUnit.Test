using System;
using Xunit;
using Bank.xUnit;

namespace Bank.xUnit.Test
{
	public class BankTest
	{
		[Fact] 
		public void DepositShouldIncrementBalance()
		{
			Account account = new Account(20.00);

			double deposit = 5.00;
			account.Deposit(deposit);
			double actualBalance = account.Balance;
			double expectedBalance = 25.00;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact] 
		public void DepositShouldThrowIfAmountIsUnderLimit()
		{
			Account account = new Account(20.00);

			Assert.Throws<Exception>(() =>
			{
				account.Deposit(-1);
			});
		}

		[Fact]
		public void DepositShouldThrowIfNaN()
		{
			Account account = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Deposit(double.NaN);
			});
		}

		[Fact]
		public void DepositShouldThrowIfPositiveInfinity()
		{
			Account account = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Deposit(double.PositiveInfinity);
			});
		}

		[Fact]
		public void DepositShouldThrowIfNegativeInfinity()
		{
			Account account = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Deposit(double.NegativeInfinity);
			});
		}

		[Fact] 
		public void WithdrawShouldWithdrawAmountIfValid()
		{
			Account account = new Account(100);

			double amount = 50;
			account.Withdraw(amount);
			double actualBalance = account.Balance;
			double expectedBalance = 50;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact] 
		public void WithdrawShouldThrowIfUnavailableFunds()
		{
			Account account = new Account(0);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw(70);
			});
		}

		[Fact] 
		public void WithdrawShouldThrowIfWithdrawAmountIsNegative()
		{
			Account account = new Account(100);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw(-1);
			});
		}

		[Fact] 
		public void WithdrawShouldThrowIfNaN()
		{
			Account account = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw(double.NaN);
			});
		}

		[Fact]
		public void WithdrawShouldThrowIfPositiveInfinity()
		{
			Account account = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw( double.PositiveInfinity);
			});
		}

		[Fact]
		public void WithdrawShouldThrowIfNegativeInfinity()
		{
			Account account = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Withdraw(double.NegativeInfinity);
			});
		}

		[Fact] 
		public void TransferShouldTransferToSavingsIfSuccessful()
		{
			Account account = new Account(500);
			Account savingsAccount = new Account(1000);

			double amount = 100;
			account.Transfer(savingsAccount, amount);
			double actualBalance = savingsAccount.Balance;
			double expectedBalance = 1100;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact]
		public void TransferShouldWithdrawFromAccountIfSuccessful()
		{
			Account account = new Account(500);
			Account savingsAccount = new Account(1000);

			double amount = 100;
			account.Transfer(savingsAccount, amount);
			double actualBalance = account.Balance;
			double expectedBalance = 400;
			Assert.Equal(expectedBalance, actualBalance);
		}

		[Fact] 
		public void TransferShouldThrowIfAmountToTransferIsNegative()
		{
			Account account = new Account(0);
			Account savingsAccount = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(savingsAccount, -1);
			});
		}

		[Fact]
		public void TransferShouldThrowIfTransferingToSameAccount()
		{
			Account account = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(account, 5);
			});
		}

		[Fact] 
		public void TransferShouldThrowIfNull()
		{
			Account account = new Account(50);
			Account savingsAccount = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(null, 0);
			});
		}

		[Fact] 
		public void TransferShouldThrowIfNaN()
		{
			Account account = new Account(50);
			Account savingsAccount = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(savingsAccount, double.NaN);
			});
		}

		[Fact] 
		public void TransferShouldThrowIfPositiveInfinity()
		{
			Account account = new Account(50);
			Account savingsAccount = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(savingsAccount, double.PositiveInfinity);
			});
		}

		[Fact]
		public void TransferShouldThrowIfNegativeInfinity()
		{
			Account account = new Account(50);
			Account savingsAccount = new Account(50);

			Assert.Throws<Exception>(() =>
			{
				account.Transfer(savingsAccount, double.NegativeInfinity);
			});
		}
	}
}
