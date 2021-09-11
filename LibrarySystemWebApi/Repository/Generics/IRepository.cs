using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibrarySystemWebApi.Repository.Generics
{
    public interface IRepository
    {
        TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new();

        int Update<TEntity>(TEntity entity) where TEntity : class, new();

        Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, new();

        int Add<TEntity>(TEntity entity) where TEntity : class, new();

        Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : class, new();
    }
}
