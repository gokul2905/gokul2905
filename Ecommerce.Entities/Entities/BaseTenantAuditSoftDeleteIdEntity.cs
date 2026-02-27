namespace Ecommerce.Entities.Entities;

public abstract class BaseTenantAuditSoftDeleteIdEntity<TKey>
    where TKey : struct
{
    public TKey Id { get; set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedOnUtc { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; set; }
}
