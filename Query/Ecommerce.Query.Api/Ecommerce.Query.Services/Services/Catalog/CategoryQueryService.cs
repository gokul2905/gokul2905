using Ecommerce.Entities.Entities;
using Ecommerce.Entities.Infrastructure;
using Ecommerce.Query.Core;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.Interfaces.Catalog;

namespace Ecommerce.Query.Services.Services.Catalog;

public sealed class CategoryQueryService(IRepository<Category> repository, IUnitOfWork unitOfWork)
    : BaseQueryService<Category, CategoryDto, Guid>(repository, unitOfWork), ICategoryQueryService
{
}
