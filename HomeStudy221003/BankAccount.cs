using System;
using System.Collections.Generic;
using System.Text;

namespace HomeStudy221003
{
    public class BankAccount
    {
        public string Number { get; }//identieringsnummer
        public string Owner { get; set; }//kontonamn
        public decimal Balance 
        {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }//Saldo
        private static int accountNumberSeed = 1234567890;//privat nr ! 
        private List<Transaction> allTransactions = new List<Transaction>();
        //lista av alla överföringar
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;    //this måste inte stå, funkar med/utan
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;//ändrar så att nästa konto har ett annat nr !
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive!");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive!");
            } //THROW avbryter, forstätter inte koden i scoopet
            if (Balance - amount < 0) 
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            //HEADER
            report.AppendLine("Date  Amount Note");
            foreach(var item in allTransactions)
            {  //ROWS
                report.AppendLine($"{item.Date.ToLongDateString()}   {item.Amount} {item.Notes}");

            }
            return report.ToString();
        }

    }
}
