using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWebApi.Repository.Generics
{
    public abstract class GenericRepository<TContext> : IRepository 
        where TContext : DbContext
    {
        protected abstract IDbContextFactory<TContext> DbContextFactory { get; }

        public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                throw new NotImplementedException();
            }
        }

        public List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                throw new NotImplementedException();
            }
        }
    }
}
