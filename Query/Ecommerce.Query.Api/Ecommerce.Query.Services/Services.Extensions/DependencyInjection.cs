using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Query.Services.Services.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddQueryServices(this IServiceCollection services)
    {
        services.AddScoped<Services.Interfaces.Catalog.ICategoryQueryService, Services.Catalog.CategoryQueryService>();
        services.AddScoped<Services.Interfaces.Catalog.IProductQueryService, Services.Catalog.ProductQueryService>();
        services.AddScoped<Services.Interfaces.Customer.ICustomerQueryService, Services.Customer.CustomerQueryService>();
        services.AddScoped<Services.Interfaces.Order.IOrderQueryService, Services.Order.OrderQueryService>();
        services.AddScoped<Services.Interfaces.Order.IOrderItemQueryService, Services.Order.OrderItemQueryService>();
        return services;
    }
}
