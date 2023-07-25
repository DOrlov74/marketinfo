using Microsoft.EntityFrameworkCore;
using MarketInfo.Model;

namespace MarketInfo.Data
{
  public class CompanyContext : DbContext
  {
    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.AddCompanyData();
   
    }
  }
}
