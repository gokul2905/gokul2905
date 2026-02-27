using Ecommerce.Command.Core;
using Ecommerce.Command.Dto;

namespace Ecommerce.Command.Services.Services.Interfaces.Order;

public interface IOrderCommandService : IBaseCommandService<OrderDto, Guid>
{
}
