using System;
using System.Collections.Generic;
namespace Bank
{
    class Program
    {
        static List<Account> listAccount = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccountMethod();
                        break;
                    case "2":
                        InsertAccountMethod();
                        break;
                    case "3":
                        TransferMethod();
                        break;
                    case "4":
                        CashOutMethod();
                        break;
                    case "5":
                        DepositMethod();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thank you for using our services!");
            Console.ReadLine();
        }

        private static void DepositMethod()
        {
            Console.WriteLine("Enter account number: ");
            int indexAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount to be deposited");
            double value = double.Parse(Console.ReadLine());

            listAccount[indexAccount].Deposit(value);
        }

        private static void TransferMethod()
        {
            Console.WriteLine("Enter the source account number");
            int indexAccountOrigin = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the target account number");
            int indexAccountTarget = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount to be transferred");
            double value = double.Parse(Console.ReadLine());

            listAccount[indexAccountOrigin].Transfer(value, listAccount[indexAccountTarget]);
        }

        private static void CashOutMethod()
        {
            Console.WriteLine("Enter account number: ");
            int indexAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount to be withdrawn");
            double value = double.Parse(Console.ReadLine());

            listAccount[indexAccount].CashOut(value);
        }

        private static void ListAccountMethod()
        {
            Console.WriteLine("List account");
            if (listAccount.Count == 0)
            {
                Console.WriteLine("No account registered");
                return;
            }
            for (int i = 0; i < listAccount.Count; i++)
            {
                Account account = listAccount[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void InsertAccountMethod()
        {
            Console.WriteLine("Insert new account");

            Console.WriteLine("Enter 1 for individuals 2 for companies");
            int getInAccountType = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the customer's name");
            string getInName = Console.ReadLine();

            Console.WriteLine("Enter initial balance");
            double getInInitialBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter credit");
            double getInCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(
                accountType: (AccountType) getInAccountType, 
                balance: getInInitialBalance,
                credit: getInCredit, 
                name: getInName
            );
            listAccount.Add(newAccount);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Bank at your service!");
            Console.WriteLine("Enter desired option:");

            Console.WriteLine("1 - List Accounts");
            Console.WriteLine("2 - Insert new accounts");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Cash out");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Get out");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
