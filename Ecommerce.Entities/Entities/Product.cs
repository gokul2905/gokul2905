using CoreKit.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.Entities;

public sealed class Product : BaseTenantAuditSoftDeleteIdEntity<Guid>
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
