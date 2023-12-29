using DrivenDomain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivenDomain.Infrastructure.Context.DatabaseConfig;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        //table
        builder.ToTable("customers");

        //columns
        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(x => x.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(x => x.Phone)
            .HasColumnName("phone")
            .IsRequired()
            .HasMaxLength(20);

        builder
            .Property(x => x.Type)
            .HasColumnName("type")
            .IsRequired()
            .HasMaxLength(20);

        builder
            .Property(x => x.Document)
            .HasColumnName("document")
            .IsRequired()
            .HasMaxLength(20);

        builder
            .Property(x => x.Address)
            .HasColumnName("address")
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder
            .Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}