using Ecommerce.Query.Core;
using Ecommerce.Query.Dto;

namespace Ecommerce.Query.Services.Services.Interfaces.Order;

public interface IOrderItemQueryService : IBaseQueryService<OrderItemDto, Guid>
{
}
