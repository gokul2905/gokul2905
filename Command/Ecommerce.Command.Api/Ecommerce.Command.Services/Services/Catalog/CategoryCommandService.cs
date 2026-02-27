using Ecommerce.Entities.Entities;
using Ecommerce.Entities.Infrastructure;
using Ecommerce.Command.Core;
using Ecommerce.Command.Dto;
using Ecommerce.Command.Services.Services.Interfaces.Catalog;

namespace Ecommerce.Command.Services.Services.Catalog;

public sealed class CategoryCommandService(IRepository<Category> repository, IUnitOfWork unitOfWork)
    : BaseCommandService<Category, CategoryDto, Guid>(repository, unitOfWork), ICategoryCommandService
{
}
