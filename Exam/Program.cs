using Exam.Models;
using Exam.Services;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Please press 1 to register customer \n press 2 to create account\n press 3 to check account balance\n  Press 4 to exit");
            var input = Console.ReadLine();
            if (input == "1")
            {
                var register = new CustomerService();
                var obj1 = register.AddCustomer();
            }
            else if (input == "2")
            {
                Console.WriteLine("Give me your customer Id");
                var id = Console.ReadLine();
                var realId = new Guid(id);
                var account = new AccountService();    
                var obj2 = account.CreateAccount(realId);
                Console.WriteLine($"{obj2}");
               
              
            }else if (input == "3")
            {
                Console.WriteLine("Give me your account number");
                var acct = Console.ReadLine();
                var account = new AccountService();
                var obj3 = account.CheckBalance(acct);
                Console.WriteLine($"Your balance is: {obj3}");
              
            }
                else if(input == "4")
            {
                Environment.Exit(0);
                Console.WriteLine("thank you for your time");
            }
                
                

        }
    }
}
