using DrivenDomain.Domain;
using Microsoft.EntityFrameworkCore;

namespace DrivenDomain.Infrastructure;

public class DrivenDomainContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    
    public DrivenDomainContext(DbContextOptions<DrivenDomainContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Customer>()
            .ToTable("customers")
            .HasKey(x => x.Id);
    }
   
}