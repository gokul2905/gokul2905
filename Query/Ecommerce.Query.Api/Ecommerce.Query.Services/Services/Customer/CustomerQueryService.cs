using CoreKit.Application.Services;
using CoreKit.Persistence.Abstractions;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.Interfaces.Customer;

namespace Ecommerce.Query.Services.Services.Customer;

public sealed class CustomerQueryService(IRepository<Customer> repository, IUnitOfWork unitOfWork)
    : BaseQueryService<Customer, CustomerDto, Guid>(repository, unitOfWork), ICustomerQueryService
{
}
