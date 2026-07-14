using Microsoft.EntityFrameworkCore;

namespace MiniWalletAPI.Data
{
    public class Transaction
    {
        public Guid Id{get;set;}
        public decimal Amount{get;set;}
        public string Type{get;set;}
        public string Status{get;set;}
        public DateTime CreatedAt{get;set;}
        
    }

    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Transaction> Transactions{get;set;}
    }
}