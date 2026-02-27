namespace Ecommerce.Query.Core;

public interface IBaseQueryService<TDto, TKey>
    where TDto : class
{
    Task<IReadOnlyList<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TDto?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
}
