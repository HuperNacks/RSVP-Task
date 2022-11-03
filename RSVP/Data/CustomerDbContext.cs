using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)   
        {
            
        }

        public DbSet<CustomerModel> Customers { get; set; }
    }
}
