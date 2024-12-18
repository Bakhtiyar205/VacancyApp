﻿using System.Linq.Expressions;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<T> : IQuery<T> where T : Entity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    Task<T?> GetAsNoTrackingAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, 
                                  IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default);

    Task<IPaginate<T>> GetPaginatedListAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    int index = 0, int size = 10, bool enableTracking = true,
                                    CancellationToken cancellationToken = default);

    Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 bool enableTracking = true,
                                                 CancellationToken cancellationToken = default);


    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
    Task<T> DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
}