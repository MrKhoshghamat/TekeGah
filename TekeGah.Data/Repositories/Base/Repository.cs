using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TekeGah.Data.Context;
using TekeGah.Domain.Entities.Common;
using TekeGah.Domain.Interfaces.Base;

namespace TekeGah.Data.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly TekeGahDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(TekeGahDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _dbSet.Where(filter).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(object? id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        return Task.FromResult(_dbSet.Where(filter).FirstOrDefault());
    }

    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _dbSet.AnyAsync(filter);
    }

    public async Task<bool> CreateAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            _context.Entry(typeof(TEntity)).State = EntityState.Modified;
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            entity.IsDeleted = true;
            await UpdateAsync(entity);
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteAsync(object id)
    {
        try
        {
            var entity = await GetByIdAsync(id);
            if (entity != null) await DeleteAsync(entity);
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
        }
    }
}