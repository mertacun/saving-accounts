
using Lab4;
using System;
using System.Collections.Generic;

class Bank
{
    static void Main()
    {
        List<Account> accounts = new List<Account>();


        Console.Write("Enter the number of months to deposit: ");
        int months;
        while (!int.TryParse(Console.ReadLine(), out months) || months <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a valid number of months.");
            Console.Write("Enter the number of months to deposit: ");
        }

        while (true)
        {
            Console.Write("\nEnter Customer Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                break;

            Console.Write($"Enter {name}'s Initial Deposit Amount (minimum $1,000.00): ");
            double initialDeposit;
            while (!double.TryParse(Console.ReadLine(), out initialDeposit) || initialDeposit < Account.MinimumInitialBalance)
            {
                Console.WriteLine($"Initial deposit amount should be at least ${Account.MinimumInitialBalance}.");
                Console.Write($"Enter {name}'s Initial Deposit Amount (minimum $1,000.00): ");
            }

            Console.Write($"Enter {name}'s Monthly Deposit Amount (minimum $50.00): ");
            double monthlyDeposit;
            while (!double.TryParse(Console.ReadLine(), out monthlyDeposit) || monthlyDeposit < Account.MinimumMonthDeposit)
            {
                Console.WriteLine($"Monthly deposit amount should be at least ${Account.MinimumMonthDeposit}.");
                Console.Write($"Enter {name}'s Monthly Deposit Amount (minimum $50.00): ");
            }

            Account account = new Account(name, initialDeposit, monthlyDeposit);
            accounts.Add(account);
        }
        Console.WriteLine();
        foreach (var account in accounts)
        {
            Console.WriteLine($"After {months} months, {account.OwnerName}'s account (#{account.AccountNumber}), has a balance of: ${account.BalanceAfterMonths(months):F2}");
        }
        Console.WriteLine("\nPress Enter to complete");
        Console.ReadLine();
    }
}

