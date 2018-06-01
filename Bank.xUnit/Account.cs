using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.xUnit
{
	public class Account
	{
		public double Interest { get; set; }
		public double Balance { get; private set; }

		public Account(double initialBalance, double interest)
		{
			this.Balance = initialBalance;
			this.Interest = interest;
		}

		public void Deposit(double amount)
		{
			if (amount <= 0)
				throw new Exception("Unable to deposit amount under 1 SEK.");
			if (double.IsNaN(amount))
				throw new Exception("The amount is not a number");
			else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
				throw new Exception("The amount exceeded the infinity limit");
			else
				this.Balance = this.Balance + amount;
		}

		public void Withdraw(double amount)
		{
			if (this.Balance <= 0)
				throw new Exception("Not enough money on the account.");
			if (double.IsNaN(amount))
				throw new Exception("The amount is not a number");
			else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
				throw new Exception("The amount exceeded the infinity limit");
			if (amount <= 0)
				throw new Exception("Unable to withdraw amount under 1 SEK.");
			else
				this.Balance = this.Balance - amount;
		}

		public bool Transfer(Account target, double amount)
		{
			if (this == target)
				throw new Exception("You can't transfer to the same account.");
			else if (double.IsNaN(amount))
				throw new Exception("The amount is not a number");
			//if (amount > this.Balance)
			//	throw new Exception("You dont have enough funds to transfer.");
			else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
				throw new Exception("The amount exceeded the infinity limit");
			else if (amount < this.Balance)
			{
				this.Withdraw(amount);
				target.Deposit(amount);
				return true;
			}
			else
				return false;
		}

		public double CalculateInterest()
		{
			this.Interest = this.Balance * Interest;

			return Interest = Interest + Balance;
		}
		//För VG.Räknar ut räntan på kontot, baserat på nuvarande saldo och räntesatsen. Sedan ska den dels returnera räntan och lägga till räntan till saldot. Eftersom den inte har några parametrar, men är beroende av saldot och räntesatsen, så behöver man sätta dem innan man anropar metoden för att testa den.
	}
}
