using System;
namespace Bank
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }
        public bool CashOut(double value)
        {
            if (this.Balance - value < (this.Credit *-1))
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }
            this.Balance -= value;
            Console.WriteLine("Current account balance {0} is {1}", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double value)
        {
            this.Balance += value;
            Console.WriteLine("Current account balance {0} is {1}", this.Name, this.Balance);
        }

        public void Transfer(double value, Account targetAccount)
        {
            if (this.CashOut(value))
            {
                targetAccount.Deposit(value);
            }
        }

        public override string ToString()
        {
            string returnString = "";
            returnString += "Account Type: " + this.AccountType + " | ";
            returnString += "Name: " + this.Name + " | ";
            returnString += "Balance: " + this.Balance + " | ";
            returnString += "Credit: " + this.Credit;
            return returnString;
        }


    }
}