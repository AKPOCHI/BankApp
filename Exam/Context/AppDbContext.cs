using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ANIBE;Integrated Security=True;database=BankExam2;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;Command Timeout=0",
                sqlServerOptionsAction: sqlOptions =>

                {
                    sqlOptions.EnableRetryOnFailure(
              maxRetryCount: 5, // Number of retry attempts
              maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
              errorNumbersToAdd: null); // Optionally specify SQL error numbers to consider as transient

                });
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }







    }


}







