using CoreKit.Application.Services;
using CoreKit.Persistence.Abstractions;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.Interfaces.Catalog;

namespace Ecommerce.Query.Services.Services.Catalog;

public sealed class ProductQueryService(IRepository<Product> repository, IUnitOfWork unitOfWork)
    : BaseQueryService<Product, ProductDto, Guid>(repository, unitOfWork), IProductQueryService
{
}
