
using Exam.Context;
using Exam.Enums;
using Exam.Models;

namespace Exam.Services
{
    internal class AccountService
    {
        public string CreateAccount(Guid customerId)
        {
            using (var context = new AppDbContext())
            {
                var userEixts = context.Customers.FirstOrDefault(x => x.Id == customerId);
                if (userEixts == null)
                {
                    return "This userId does not exists on customers table";
                }           
            }

            var account = new Account();
            Console.WriteLine("press 1 to create a current account \n press 2 to create savings account");
            var input = Console.ReadLine();
            if (input == "1")
            {
                account.AccountType = AccountTypeEnum.current;
            }
            else if (input == "2")
            {
                account.AccountType = AccountTypeEnum.savings;
            }
            account.AccountNumber = GenerateAccountNumber();
            account.CustomerId = customerId;

            using (var context = new AppDbContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
            return $"here are the customer details\n" +
                $"account id: {customerId}\n" +
                $"accountNumber:{account.AccountNumber}\n" +
                $"account type{account.AccountType}";

        }

        public decimal CheckBalance(string accNo)
        {
            using (var context = new AppDbContext())
            {
                var record = context.Accounts.FirstOrDefault(c => c.AccountNumber == accNo);
                return record.AccountBalance;
            }
            
        }
        public string GenerateAccountNumber()
        {
            Random random = new Random();
            var firstDigit = random.Next(1, 10).ToString();
            string remainingDigit = string.Empty;
            for (int i = 0; i < 9; i++)
            {
                remainingDigit += random.Next(2, 9).ToString();
            }
            return firstDigit + remainingDigit;
        }

    }
}
