using Exam.Context;
using Exam.Models;

namespace Exam.Services
{
    internal class CustomerService
    {
        public string AddCustomer()
        {
            Console.WriteLine("Input your FirstName");
            var firstName = Console.ReadLine();

            Console.WriteLine("Input your LastName");
            var lastName = Console.ReadLine();

            Console.WriteLine("Input your email");
            var email = Console.ReadLine();


            Console.WriteLine("Input your phonenumber");
            var phoneNumber = Console.ReadLine();

            Console.WriteLine("Input your password");
            var passWord = Console.ReadLine();

            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                PassWord = passWord
            };

            using (var Context = new AppDbContext())
            {
                Context.Customers.Add(customer);
                Context.SaveChanges();

            }
            return "customer added successfully";

        }

        public string UpdateCustomerPhoneNumber(Guid customerId, string phoneNumber)
        {
            using (var context = new AppDbContext())
            {
                var customerExist = context.Customers.FirstOrDefault(v => v.Id == customerId);
                if (customerExist != null)
                {
                    customerExist.PhoneNumber = phoneNumber;
                    context.SaveChanges();
                    return "phone number updated successfully";
                }
            }
            return "Something went wrong while updating phone number";
        }
    }
}
