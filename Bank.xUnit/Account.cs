using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.xUnit
{
	public class Account
	{
		public double Balance { get; private set; }
		//Balance ska vara kontots saldo.Använd egenskapen för att kontrollera vad saldot är efter varje funktionsanrop.Man ska inte kunna ändra saldot via egenskapen, bara genom klassens metoder.Behöver inte testas.

		public Account(double initialBalance) { }
		//Konstruktorn ska anropas med det värde ni vill att kontot ska ha från början. (Om ni gör VG-versionen så ska räntesatsen också vara en parameter.)

		public void Deposit(double amount) { }
		//Ökar saldot på kontot med amount.Alla double-tal som rimligtvis kan tänkas motsvara ett pengabelopp är tillåtna värden.Om funktionen får ett otillåtet double-tal som parameter ska den kasta ett Exception med ett lämpligt felmeddelande.

		public void Withdraw(double amount) { }
		//Minskar saldot på kontot med amount, förutsatt att det finns tillräckligt med pengar på kontot.Om det inte gör det ska funktionen inte dra några pengar utan i stället kasta ett Exception med ett lämpligt felmeddelande.Samma sak om amount är ett otillåtet double-tal.

		public bool Transfer(Account target, double amount) { return true;  }
		//Minskar saldot på kontot med amount och ökar med motsvarande belopp på mottagarkontot, förutsatt att inget har gått fel. Men det finns ganska många anledningar till att det kan gå fel.

		public double CalculateInterest() { return 2.1; }
		//För VG.Räknar ut räntan på kontot, baserat på nuvarande saldo och räntesatsen. Sedan ska den dels returnera räntan och lägga till räntan till saldot. Eftersom den inte har några parametrar, men är beroende av saldot och räntesatsen, så behöver man sätta dem innan man anropar metoden för att testa den.
	}
}
