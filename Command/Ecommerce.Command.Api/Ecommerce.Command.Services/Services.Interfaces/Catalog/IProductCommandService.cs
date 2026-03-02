using Ecommerce.Command.Dto;
using CoreKit.Application.Abstractions;

namespace Ecommerce.Command.Services.Services.Interfaces.Catalog;

public interface IProductCommandService : IBaseCommandService<ProductDto, Guid>
{
}
