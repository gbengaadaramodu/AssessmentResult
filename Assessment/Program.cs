using System;
using System.Collections.Generic;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int Amount;
                Console.WriteLine("Enter the Task you want to test\n Enter 1 for task 1 \n Enter 2 for task 2!");
                var taskId = Console.ReadLine();

                // Enter the amount to be transferred.
                Console.Write("Amount to be transferred: ");
                var InputAmount = Console.ReadLine();

                bool isValid = Int32.TryParse(InputAmount, out Amount);
                if (!isValid)
                    Console.WriteLine("Invalid amount.");
                else
                {
                    if (taskId == "1")
                    {
                        var response = CalculateCharges(Amount);

                        //the charge to the amount to be transferred    
                        Console.WriteLine("The charges is {0}", response);
                    }
                    else if (taskId == "2")
                    {
                        var transfer = Transfer(Amount);

                        Console.WriteLine("Amount \t Transfer Amount \t Charge \t Debit Amount (Transfer Amount + Charge)");
                        Console.WriteLine("{0} \t {1} \t {2} \t {3}", Amount, transfer.TransferAmount, transfer.ChargeAmount, Amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid task ID");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred - {0}", ex.ToString());
            }

            Console.ReadKey();
        }


        static int CalculateCharges(int amount)
        {
            int feeAmount = 0;
            var response = BaseService.LoadJsonFile();

            foreach (var eachResponse in response.fees)
            {
                if (amount >= eachResponse.minAmount && amount <= eachResponse.maxAmount)
                    feeAmount = eachResponse.feeAmount;
            }

            return feeAmount;
        }


        static FundTransfer Transfer(int amount)
        {
            var fund = new FundTransfer();

            //get the charges for the amount
            fund.ChargeAmount = CalculateCharges(amount);

            //get the amount that will be transferred
            fund.TransferAmount = amount - fund.ChargeAmount;

            return fund;
        }

    }
}
