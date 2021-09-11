using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibrarySystemWebApi.Repository.Generics
{
    public interface IRepository
    {
        TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, new();
        List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, new();
    }
}
