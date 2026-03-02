using CoreKit.Application.Services;
using CoreKit.Persistence.Abstractions;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.Interfaces.Order;

namespace Ecommerce.Query.Services.Services.Order;

public sealed class OrderQueryService(IRepository<Order> repository, IUnitOfWork unitOfWork)
    : BaseQueryService<Order, OrderDto, Guid>(repository, unitOfWork), IOrderQueryService
{
}
