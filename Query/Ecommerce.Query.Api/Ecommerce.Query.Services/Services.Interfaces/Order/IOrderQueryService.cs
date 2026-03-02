using Ecommerce.Query.Dto;
using CoreKit.Application.Abstractions;

namespace Ecommerce.Query.Services.Services.Interfaces.Order;

public interface IOrderQueryService : IBaseQueryService<OrderDto, Guid>
{
}
