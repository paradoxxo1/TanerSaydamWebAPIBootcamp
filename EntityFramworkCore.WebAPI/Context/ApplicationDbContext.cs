using EntityFramworkCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramworkCore.WebAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0E4KP6A\\SQLEXPRESS;Initial Catalog=eCommerceDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
        public DbSet<Product> Products { get; set; }
    }

}
