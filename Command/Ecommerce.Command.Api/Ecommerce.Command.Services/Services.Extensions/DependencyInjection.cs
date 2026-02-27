using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Command.Services.Services.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandServices(this IServiceCollection services)
    {
        services.AddScoped<Services.Interfaces.Catalog.ICategoryCommandService, Services.Catalog.CategoryCommandService>();
        services.AddScoped<Services.Interfaces.Catalog.IProductCommandService, Services.Catalog.ProductCommandService>();
        services.AddScoped<Services.Interfaces.Customer.ICustomerCommandService, Services.Customer.CustomerCommandService>();
        services.AddScoped<Services.Interfaces.Order.IOrderCommandService, Services.Order.OrderCommandService>();
        services.AddScoped<Services.Interfaces.Order.IOrderItemCommandService, Services.Order.OrderItemCommandService>();
        return services;
    }
}
