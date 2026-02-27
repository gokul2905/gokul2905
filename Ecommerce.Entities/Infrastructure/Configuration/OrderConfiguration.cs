using Ecommerce.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Entities.Infrastructure.Configuration;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OrderDate).IsRequired();
        builder.Property(x => x.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasIndex(x => x.CustomerId).HasDatabaseName("IX_Order_CustomerId");

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
