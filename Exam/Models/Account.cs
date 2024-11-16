using Exam.Enums;

namespace Exam.Models
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public decimal AccountBalance { get; set; } = decimal.Zero;


    }
}
