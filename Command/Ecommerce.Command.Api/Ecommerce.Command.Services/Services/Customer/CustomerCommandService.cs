using Ecommerce.Entities.Entities;
using Ecommerce.Entities.Infrastructure;
using Ecommerce.Command.Core;
using Ecommerce.Command.Dto;
using Ecommerce.Command.Services.Services.Interfaces.Customer;

namespace Ecommerce.Command.Services.Services.Customer;

public sealed class CustomerCommandService(IRepository<Customer> repository, IUnitOfWork unitOfWork)
    : BaseCommandService<Customer, CustomerDto, Guid>(repository, unitOfWork), ICustomerCommandService
{
}
