namespace Ecommerce.Entities.Entities;

public sealed class Order : BaseTenantAuditSoftDeleteIdEntity<Guid>
{
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public Customer? Customer { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
