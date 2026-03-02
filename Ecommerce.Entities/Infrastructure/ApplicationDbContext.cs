using System.Linq.Expressions;
using CoreKit.Domain.Entities;
using Ecommerce.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Entities.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        ApplySoftDeleteFilter(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditConfiguration();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ApplyAuditConfiguration();
        return base.SaveChanges();
    }

    private void ApplyAuditConfiguration()
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<BaseTenantAuditSoftDeleteIdEntity<Guid>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOnUtc = utcNow;
                entry.Entity.UpdatedOnUtc = utcNow;
                entry.Entity.TenantId = entry.Entity.TenantId == Guid.Empty
                    ? Guid.Parse("00000000-0000-0000-0000-000000000001")
                    : entry.Entity.TenantId;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedOnUtc = utcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
                entry.Entity.DeletedOnUtc = utcNow;
                entry.Entity.UpdatedOnUtc = utcNow;
            }
        }
    }

    private static void ApplySoftDeleteFilter(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(BaseTenantAuditSoftDeleteIdEntity<Guid>).IsAssignableFrom(entityType.ClrType))
            {
                continue;
            }

            var parameter = Expression.Parameter(entityType.ClrType, "entity");
            var propertyMethod = typeof(EF).GetMethod(nameof(EF.Property))!.MakeGenericMethod(typeof(bool));
            var isDeletedProperty = Expression.Call(propertyMethod, parameter, Expression.Constant(nameof(BaseTenantAuditSoftDeleteIdEntity<Guid>.IsDeleted)));
            var compareExpression = Expression.Equal(isDeletedProperty, Expression.Constant(false));
            var lambda = Expression.Lambda(compareExpression, parameter);
            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
        }
    }
}
