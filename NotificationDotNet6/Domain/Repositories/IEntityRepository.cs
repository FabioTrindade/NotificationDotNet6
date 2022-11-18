using System;
using System.Linq.Expressions;
using NotificationDotNet6.Domain.Abstracts;

namespace NotificationDotNet6.Domain.Repositories;

public interface IEntityRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task<TEntity> Create(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task Delete(TEntity entity);

    Task<IEnumerable<TEntity>> GetAll();

    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> GetById(Guid id);

    Task<List<T>> QueryAsync<T>(string query, object? parameter = null);

    Task<T> QueryFirstAsync<T>(string query, object? parameter = null);
}