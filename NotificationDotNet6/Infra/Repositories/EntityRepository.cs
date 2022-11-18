using System.Linq.Expressions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NotificationDotNet6.Domain.Abstracts;
using NotificationDotNet6.Domain.Repositories;
using NotificationDotNet6.Infra.Contexts;

namespace NotificationDotNet6.Infra.Repositories;

public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly NotificationDataContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    //private readonly SqliteConnection _connection;

    public EntityRepository(NotificationDataContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        // _connection = connection;
    }

    public virtual async Task<TEntity> Create(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate)?.FirstOrDefaultAsync();
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await _dbSet.AsNoTracking().FirstAsync(t => t.Id == id);
    }

    public Task<List<T>> QueryAsync<T>(string query, object? parameter = null)
    {
        throw new NotImplementedException();
    }

    public Task<T> QueryFirstAsync<T>(string query, object? parameter = null)
    {
        throw new NotImplementedException();
    }

    public virtual async Task Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}