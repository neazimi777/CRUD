using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Persistence.Configuration
{
    public class CustomerEventConfig : IEntityTypeConfiguration<CustomerEvent>
    {
        public void Configure(EntityTypeBuilder<CustomerEvent> builder)
        {
            builder.ToTable("CustomerEvent", "dbo");
            builder.Property(k => k.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnType("DATE").IsRequired();
            builder.Property(p => p.Email).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(p => p.PhoneNumber).HasColumnType("CHAR").HasMaxLength(11).IsRequired();
            builder.Property(p => p.BankAccountNumber).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(p => p.IsActive).HasColumnType("BIT").IsRequired();
            builder.Property(p => p.CreateTime).HasColumnType("DATETIME2").HasMaxLength(7).IsRequired();
        }
    }
}
