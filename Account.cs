using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Account
    {
        public int AccountNumber { get; }
        public string OwnerName { get; }
        public double Balance { get; private set; }
        public double MonthlyDepositAmount { get; }

        public static double MonthlyFee { get; } = 4.0;
        public static double MonthlyInterestRate { get; } = 0.0025;
        public static double MinimumInitialBalance { get; } = 1000;
        public static double MinimumMonthDeposit { get; } = 50;

        private static Random random = new Random();

        public Account(string ownerName, double initialDeposit, double monthlyDepositAmount)
        {
            AccountNumber = random.Next(90000, 100000);
            OwnerName = ownerName;
            Balance = initialDeposit;
            MonthlyDepositAmount = monthlyDepositAmount;
        }

        public void DeductMonthlyFee()
        {
            Balance -= MonthlyFee;
        }

        public void AddMonthlyInterest()
        {
            Balance += Balance * MonthlyInterestRate;
        }

        public void AddMonthlyDeposit()
        {
            Balance += MonthlyDepositAmount;
        }

        public double BalanceAfterMonths(int months)
        {
            for (int i = 0; i < months; i++)
            {
                DeductMonthlyFee();
                AddMonthlyInterest();
                AddMonthlyDeposit();
            }
            return Balance;
        }
    }
}
