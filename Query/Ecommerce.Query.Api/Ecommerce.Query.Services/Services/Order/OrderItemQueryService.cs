using CoreKit.Application.Services;
using CoreKit.Persistence.Abstractions;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.Interfaces.Order;

namespace Ecommerce.Query.Services.Services.Order;

public sealed class OrderItemQueryService(IRepository<OrderItem> repository, IUnitOfWork unitOfWork)
    : BaseQueryService<OrderItem, OrderItemDto, Guid>(repository, unitOfWork), IOrderItemQueryService
{
}
