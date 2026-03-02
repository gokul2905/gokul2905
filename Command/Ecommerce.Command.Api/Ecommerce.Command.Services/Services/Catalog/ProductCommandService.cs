using CoreKit.Application.Services;
using CoreKit.Persistence.Abstractions;
using Ecommerce.Entities.Entities;
using Ecommerce.Command.Dto;
using Ecommerce.Command.Services.Services.Interfaces.Catalog;

namespace Ecommerce.Command.Services.Services.Catalog;

public sealed class ProductCommandService(IRepository<Product> repository, IUnitOfWork unitOfWork)
    : BaseCommandService<Product, ProductDto, Guid>(repository, unitOfWork), IProductCommandService
{
}
