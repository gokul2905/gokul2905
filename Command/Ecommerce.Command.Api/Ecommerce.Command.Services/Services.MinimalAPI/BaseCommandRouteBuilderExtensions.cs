using Ecommerce.Command.Core;

namespace Ecommerce.Command.Services.Services.MinimalAPI;

public static class BaseCommandRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapBaseCommandRoutes<TEntity, TDto, TKey>(this IEndpointRouteBuilder endpoints, string pattern)
        where TEntity : class
        where TDto : class
    {
        var group = endpoints.MapGroup(pattern);
        group.MapGet("/", async (IBaseCommandService<TDto, TKey> service, CancellationToken cancellationToken) =>
            Results.Ok(await service.GetAllAsync(cancellationToken)));

        group.MapGet("/{id:guid}", async (TKey id, IBaseCommandService<TDto, TKey> service, CancellationToken cancellationToken) =>
        {
            var model = await service.GetByIdAsync(id, cancellationToken);
            return model is null ? Results.NotFound() : Results.Ok(model);
        });

        group.MapPost("/", async (TDto dto, IBaseCommandService<TDto, TKey> service, CancellationToken cancellationToken) =>
            Results.Ok(await service.CreateAsync(dto, cancellationToken)));

        group.MapPut("/{id:guid}", async (TKey id, TDto dto, IBaseCommandService<TDto, TKey> service, CancellationToken cancellationToken) =>
        {
            var updated = await service.UpdateAsync(id, dto, cancellationToken);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        });

        group.MapDelete("/{id:guid}", async (TKey id, IBaseCommandService<TDto, TKey> service, CancellationToken cancellationToken) =>
            await service.DeleteAsync(id, cancellationToken) ? Results.NoContent() : Results.NotFound());

        return endpoints;
    }
}
