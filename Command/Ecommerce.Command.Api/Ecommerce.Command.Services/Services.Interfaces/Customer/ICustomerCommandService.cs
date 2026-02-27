using Ecommerce.Command.Core;
using Ecommerce.Command.Dto;

namespace Ecommerce.Command.Services.Services.Interfaces.Customer;

public interface ICustomerCommandService : IBaseCommandService<CustomerDto, Guid>
{
}
