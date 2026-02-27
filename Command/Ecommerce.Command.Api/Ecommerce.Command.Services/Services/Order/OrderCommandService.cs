using Ecommerce.Entities.Entities;
using Ecommerce.Entities.Infrastructure;
using Ecommerce.Command.Core;
using Ecommerce.Command.Dto;
using Ecommerce.Command.Services.Services.Interfaces.Order;

namespace Ecommerce.Command.Services.Services.Order;

public sealed class OrderCommandService(IRepository<Order> repository, IUnitOfWork unitOfWork)
    : BaseCommandService<Order, OrderDto, Guid>(repository, unitOfWork), IOrderCommandService
{
}
