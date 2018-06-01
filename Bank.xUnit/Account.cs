using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.xUnit
{
	public class Account
	{
		//public double Interest { get; set; }
		public double Balance { get; private set; }

		public Account(double initialBalance/*, double interest*/)
		{
			this.Balance = initialBalance;
		}

		public void Deposit(double amount)
		{
			if (amount <= 0)
				throw new Exception("Unable to deposit amount under 1 SEK.");
			else if (amount >= 50000)
				throw new Exception("Unable to deposit more than 50 000 SEK.");
			else
				this.Balance = this.Balance + amount;
		}

		public void Withdraw(double amount)
		{
			if (this.Balance <= 0)
				throw new Exception("Not enough money on the account.");
			else if (amount > 5000)
				throw new Exception("Not allowed to withdraw more than 5000 SEK.");
			if (amount <= 0)
				throw new Exception("Unable to withdraw amount under 1 SEK.");
			else
				this.Balance = this.Balance - amount;
		}

		public bool Transfer(Account target, double amount)
		{
			if (this == target)
				throw new Exception("You can't transfer to the same account.");
			if (amount > this.Balance)
				throw new Exception("You dont have enough funds to transfer.");
			else if (amount < this.Balance)
			{
				this.Withdraw(amount);
				target.Deposit(amount);
				return true;
			}
			else
				return true;
		}


		public double CalculateInterest() { return 2.1; }
		//För VG.Räknar ut räntan på kontot, baserat på nuvarande saldo och räntesatsen. Sedan ska den dels returnera räntan och lägga till räntan till saldot. Eftersom den inte har några parametrar, men är beroende av saldot och räntesatsen, så behöver man sätta dem innan man anropar metoden för att testa den.
	}
}
