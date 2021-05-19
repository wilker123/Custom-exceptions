using CustomExceptions.Entities;
using CustomExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data: ");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw Limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(number, holder,balance, withdrawLimit);
                account.Deposit(balance);
                Console.WriteLine();

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                account.Withdraw(amount);

                Console.WriteLine("New balance: " + account.Balance);
            }
            catch (DomainExceptions e)
            {
                Console.WriteLine("Error account: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
