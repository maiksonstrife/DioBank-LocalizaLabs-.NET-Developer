using System;
using Enums;
using System.Collections.Generic;
using Classes;

namespace _DioBank
{
    class Program
    {
        static List<Account> accountList  = new List<Account>();

        static void Main(string[] args)
        {
            string userOption = Options();

            while(userOption != "X")
            {
                switch(userOption)
                {
                    case "1":
                    ListAllAccounts();
                    break;
                    
                    case "2":
                    AddNewAccount();
                    break;

                    case "3":
                    Transfer();
                    break;

                    case "4":
                    Withdraw();
                    break;
                    
                    case "5":
                    Deposit();
                    break;
                    
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                userOption = Options();
            }
            Console.WriteLine("Exiting...");
        }

        private static void Transfer()
        {
            Console.WriteLine("[Transfer] ");

            Console.Write("Origin Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Destination Account Number: ");
            int destinationAccountNumber = int.Parse(Console.ReadLine());
            Console.Write("Deposit Value: ");
            double depositValue = double.Parse(Console.ReadLine());
            accountList[accountNumber].Transfer(depositValue, accountList[destinationAccountNumber]);
        }

        private static void Deposit()
        {
            Console.WriteLine("[DEPOSIT] ");

            Console.Write("Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Deposit Value: ");
            double depositValue = double.Parse(Console.ReadLine());
            accountList[accountNumber].Deposit(depositValue);
        }

        private static void Withdraw()
        {
            Console.WriteLine("[WITHDRAW] ");

            Console.Write("Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Withdraw Value: ");
            double withDrawValue = double.Parse(Console.ReadLine());
            accountList[accountNumber].WithDraw(withDrawValue);
        }

        private static void ListAllAccounts()
        {
            Console.WriteLine("Listing Accounts...");

            if(accountList.Count == 0)
            {
              Console.WriteLine("None Account Avaliable");
              return;
            }

            for(int i = 0; i < accountList.Count; i++)
            {
                Account account = accountList[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void AddNewAccount()
        {
            Console.WriteLine("Creating New Account... Insert Option: ");
            Console.WriteLine("1 - PhysicalPerson");
            Console.WriteLine("2 - LegalPerson");
            int typeOfAccount = int.Parse(Console.ReadLine());

            Console.Write("Insert Account Name: ");
            string accountName = Console.ReadLine();

            Console.Write("Insert Initial Balance: ");
            double accountBalance = double.Parse(Console.ReadLine());

            Console.Write("Insert Account Credit: ");
            double accountCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(
                (AccountType) typeOfAccount,
                accountName,
                accountCredit,
                accountBalance
            );
            accountList.Add(newAccount);
        }

        private static string Options()
        {
            Console.WriteLine();
            Console.WriteLine("1 - List Accounts");
            Console.WriteLine("2 - Add New Account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Refresh Screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}