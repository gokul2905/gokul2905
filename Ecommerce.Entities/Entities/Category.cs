using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.Entities;

public sealed class Category : BaseTenantAuditSoftDeleteIdEntity<Guid>
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
