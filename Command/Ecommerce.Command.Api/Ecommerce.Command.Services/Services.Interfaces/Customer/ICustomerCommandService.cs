using Ecommerce.Command.Dto;
using CoreKit.Application.Abstractions;

namespace Ecommerce.Command.Services.Services.Interfaces.Customer;

public interface ICustomerCommandService : IBaseCommandService<CustomerDto, Guid>
{
}
