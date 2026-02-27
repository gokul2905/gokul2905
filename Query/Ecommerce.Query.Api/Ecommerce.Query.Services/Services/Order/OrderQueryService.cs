using Ecommerce.Entities.Entities;
using Ecommerce.Entities.Infrastructure;
using Ecommerce.Query.Core;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.Interfaces.Order;

namespace Ecommerce.Query.Services.Services.Order;

public sealed class OrderQueryService(IRepository<Order> repository, IUnitOfWork unitOfWork)
    : BaseQueryService<Order, OrderDto, Guid>(repository, unitOfWork), IOrderQueryService
{
}
