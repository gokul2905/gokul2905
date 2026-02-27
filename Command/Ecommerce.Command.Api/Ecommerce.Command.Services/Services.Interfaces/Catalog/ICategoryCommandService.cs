using Ecommerce.Command.Core;
using Ecommerce.Command.Dto;

namespace Ecommerce.Command.Services.Services.Interfaces.Catalog;

public interface ICategoryCommandService : IBaseCommandService<CategoryDto, Guid>
{
}
