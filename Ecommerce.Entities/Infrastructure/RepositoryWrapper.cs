namespace Ecommerce.Entities.Infrastructure;

public interface IRepositoryWrapper
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
}

public sealed class RepositoryWrapper(IServiceProvider serviceProvider) : IRepositoryWrapper
{
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        => serviceProvider.GetRequiredService<IRepository<TEntity>>();
}
