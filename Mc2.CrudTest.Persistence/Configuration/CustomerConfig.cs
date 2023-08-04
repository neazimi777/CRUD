
using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Persistence.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Domain.Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo");
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnType("DATE").IsRequired();
            builder.Property(p => p.Email).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.PhoneNumber).HasColumnType("CHAR").HasMaxLength(11).IsRequired();
            builder.Property(p => p.BankAccountNumber).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(p => p.IsActive).HasColumnType("BIT").IsRequired();
            builder.Property(p => p.CheckDuplicate).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.CheckDuplicate).IsUnique();
            builder.Property(p => p.CreateTime).HasColumnType("DATETIME2").HasMaxLength(7).IsRequired();
            builder.Property(p => p.LastModificationTime).HasColumnType("DATETIME2").HasMaxLength(7).IsRequired(false);
        }

    }
}
