using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.Entities;

public sealed class Customer : BaseTenantAuditSoftDeleteIdEntity<Guid>
{
    [Required]
    [MaxLength(200)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
