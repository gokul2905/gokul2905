using Ecommerce.Query.Dto;
using CoreKit.Application.Abstractions;

namespace Ecommerce.Query.Services.Services.Interfaces.Customer;

public interface ICustomerQueryService : IBaseQueryService<CustomerDto, Guid>
{
}
