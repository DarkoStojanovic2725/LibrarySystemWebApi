using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibrarySystem.Repository.Repository.Generics
{
    public interface IRepository
    {
        TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null,
            params Expression<Func<TEntity, object>>[] includeExpression) where TEntity : class, new();

        List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null,
            params Expression<Func<TEntity, object>>[] includeExpression) where TEntity : class, new();

        int Update<TEntity>(TEntity entity) where TEntity : class, new();

        Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, new();

        int Add<TEntity>(TEntity entity) where TEntity : class, new();

        Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : class, new();

        bool Any<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        int Delete<TEntity>(TEntity entity) where TEntity : class, new();

        Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class, new();
    }
}
