using System;

namespace HomeStudy221003
{
    class Program
    {
        static void Main(string[] args)
        {
            //10 siffror identifiera bankkonto
            //sträng för kontoägare
            //saldo som kan ses
            //kan sätta in pengar
            //kan ta ut pengar
            //startsaldo måste vara positivt
            //uttag kan inte resultera i negativt saldo
            var account = new BankAccount("Daniel", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

            account.MakeWithdrawal(120, DateTime.Now, "food");
            Console.WriteLine(account.Balance);//köper mat,120 & visar saldo

            Console.WriteLine(account.GetAccountHistory());



        }
    }
}
