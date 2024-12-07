using System.Linq.Expressions;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IRepository<T> : IQuery<T> where T : Entity
{
    T? Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    IPaginate<T> GetPaginatedList(Expression<Func<T, bool>>? predicate = null,
                         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0, int size = 10,
                         bool enableTracking = true);
    IList<T> GetList(Expression<Func<T, bool>>? predicate = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                  Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                  bool enableTracking = true);

    T Add(T entity);
    IEnumerable<T> AddRange(IEnumerable<T> entities);
    T Update(T entity);
    IEnumerable<T> UpdateRange(IEnumerable<T> entities);
    T Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    DbSet<T> GetDbSet();
}