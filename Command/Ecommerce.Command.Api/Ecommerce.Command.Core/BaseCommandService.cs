using System.Reflection;
using Ecommerce.Entities.Entities;
using Ecommerce.Entities.Infrastructure;

namespace Ecommerce.Command.Core;

public abstract class BaseCommandService<TEntity, TDto, TKey>(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
    : IBaseCommandService<TDto, TKey>
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

    public async Task<TDto> CreateAsync(TDto dto, CancellationToken cancellationToken = default)
    {
        var entity = ToEntity(dto);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return ToDto(entity);
    }

    public async Task<TDto?> UpdateAsync(TKey id, TDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(Guid.Parse(id!.ToString()!), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        Merge(dto, entity);
        repository.Update(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return ToDto(entity);
    }

    public async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(Guid.Parse(id!.ToString()!), cancellationToken);
        if (entity is null)
        {
            return false;
        }

        repository.Delete(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
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
