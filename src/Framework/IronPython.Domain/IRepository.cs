namespace IronPython.Domain
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
    }
}