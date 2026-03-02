using CoreKit.Persistence.Abstractions;
using Ecommerce.Entities.Entities;

namespace Ecommerce.Entities.Infrastructure;

public interface IRepositoryWrapper
{
    IRepository<Category> Categories { get; }
    IRepository<Product> Products { get; }
    IRepository<Customer> Customers { get; }
    IRepository<Order> Orders { get; }
    IRepository<OrderItem> OrderItems { get; }
}

public sealed class RepositoryWrapper : IRepositoryWrapper
{
    public RepositoryWrapper(
        IRepository<Category> categories,
        IRepository<Product> products,
        IRepository<Customer> customers,
        IRepository<Order> orders,
        IRepository<OrderItem> orderItems)
    {
        Categories = categories;
        Products = products;
        Customers = customers;
        Orders = orders;
        OrderItems = orderItems;
    }

    public IRepository<Category> Categories { get; }
    public IRepository<Product> Products { get; }
    public IRepository<Customer> Customers { get; }
    public IRepository<Order> Orders { get; }
    public IRepository<OrderItem> OrderItems { get; }
}
