using Ecommerce.Query.Dto;
using CoreKit.Application.Abstractions;

namespace Ecommerce.Query.Services.Services.Interfaces.Catalog;

public interface ICategoryQueryService : IBaseQueryService<CategoryDto, Guid>
{
}
