using CoreKit.Application.Services;
using CoreKit.Persistence.Abstractions;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.Interfaces.Catalog;

namespace Ecommerce.Query.Services.Services.Catalog;

public sealed class CategoryQueryService(IRepository<Category> repository, IUnitOfWork unitOfWork)
    : BaseQueryService<Category, CategoryDto, Guid>(repository, unitOfWork), ICategoryQueryService
{
}
