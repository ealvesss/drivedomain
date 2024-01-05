using DrivenDomain.Domain.Entities;
using DrivenDomain.Infrastructure.Context.DatabaseConfig;
using Microsoft.EntityFrameworkCore;

namespace DrivenDomain.Infrastructure.Context;

public class DrivenDomainContext : DbContext
{
    public DrivenDomainContext(DbContextOptions<DrivenDomainContext> options)
        : base(options)
    {
    }

    public DbSet<Customer>? Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}