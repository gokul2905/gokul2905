using System.Reflection;
using Ecommerce.Entities.Entities;
using Ecommerce.Entities.Infrastructure;

namespace Ecommerce.Query.Core;

public abstract class BaseQueryService<TEntity, TDto, TKey>(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
    : IBaseQueryService<TDto, TKey>
    where TEntity : BaseTenantAuditSoftDeleteIdEntity<Guid>, new()
    where TDto : class, new()
{
    public async Task<IReadOnlyList<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(cancellationToken);
        return entities.Select(ToDto).ToList();
    }

    public async Task<TDto?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(Guid.Parse(id!.ToString()!), cancellationToken);
        return entity is null ? null : ToDto(entity);
    }


    protected virtual TDto ToDto(TEntity entity)
    {
        var dto = new TDto();
        Merge(entity, dto);
        return dto;
    }

    protected virtual TEntity ToEntity(TDto dto)
    {
        var entity = new TEntity();
        Merge(dto, entity);
        return entity;
    }

    private static void Merge<TSource, TDestination>(TSource source, TDestination destination)
    {
        var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(p => p.Name, p => p);

        foreach (var targetProperty in typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!targetProperty.CanWrite || !sourceProperties.TryGetValue(targetProperty.Name, out var sourceProperty))
            {
                continue;
            }

            var value = sourceProperty.GetValue(source);
            targetProperty.SetValue(destination, value);
        }
    }
}
