using Ecommerce.Command.Dto;
using CoreKit.Application.Abstractions;

namespace Ecommerce.Command.Services.Services.Interfaces.Order;

public interface IOrderCommandService : IBaseCommandService<OrderDto, Guid>
{
}
