using Enums;
using System;

namespace Classes
{
    public class Account
    {
        private string Name { get; set; }
        private double Credit { get; set; }
        private double Balance { get; set; }
        private AccountType AccountType { get; set; }
        public Account(AccountType accountType, string name, double credit, double balance)
        {
            this.Name = name;
            this.Credit = credit;
            this.Balance = balance;
            this.AccountType = accountType;
        }

        public bool WithDraw(double withDrawValue)
        {
            if(this.Balance - withDrawValue < (this.Credit * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Balance -= withDrawValue;
            Console.WriteLine("O saldo conta de {0} é {1}", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;
            Console.WriteLine("O saldo conta de {0} é {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account destinyAccount)
        {
            if(this.WithDraw(transferValue)) destinyAccount.Deposit(transferValue);
        }

        public override string ToString()
        {
            string accountInfo = "";
            accountInfo += "Account Type: " + this.AccountType + " | ";
            accountInfo += "Name: " + this.Name + " | ";
            accountInfo += "Balance: " + this.Balance + " | ";
            accountInfo += "Credit: " + this.Credit;
            return accountInfo;
        }
    }
}