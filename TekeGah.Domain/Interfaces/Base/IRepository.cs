using System.Linq.Expressions;
using TekeGah.Domain.Entities.Common;

namespace TekeGah.Domain.Interfaces.Base;

public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
{
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> GetByIdAsync(object? id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);
    Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter);
    Task<bool> CreateAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> DeleteAsync(object id);
}