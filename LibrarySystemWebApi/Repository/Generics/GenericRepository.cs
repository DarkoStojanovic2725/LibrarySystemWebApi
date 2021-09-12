using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWebApi.Repository.Generics
{
    public abstract class GenericRepository<TContext> : IRepository 
        where TContext : DbContext
    {
        protected abstract IDbContextFactory<TContext> DbContextFactory { get; }

        private IQueryable<TEntity> QueryBuilder<TEntity>(TContext context,
            Expression<Func<TEntity, bool>> expression = null,
            params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class, new()
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includeExpressions != null && includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query,
                    (currentEntity, includeExpression) => currentEntity.Include(includeExpression));
            }

            return query;
        }

        public async Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                return await QueryBuilder(ctx, expression).FirstOrDefaultAsync();
            }
        }

        public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                return QueryBuilder(ctx, expression).FirstOrDefault();
            }
        }

        public List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                return QueryBuilder(ctx, expression).ToList();
            }
        }

        public async Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null,
            params Expression<Func<TEntity, object>>[] includeExpression) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                return await QueryBuilder(ctx, expression, includeExpression).ToListAsync();
            }
        }

        public int Update<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                var set = ctx.Set<TEntity>();
                set.Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                return ctx.SaveChanges();
            }
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                var set = ctx.Set<TEntity>();
                set.Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                return await ctx.SaveChangesAsync();
            }
        }

        public int Add<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                var set = ctx.Set<TEntity>();
                set.Add(entity);
                return ctx.SaveChanges();
            }
        }

        public async Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                var set = ctx.Set<TEntity>();
                set.Add(entity);
                return await ctx.SaveChangesAsync();
            }
        }

        public bool Any<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                return QueryBuilder(ctx, expression).Any();
            }
        }

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression = null) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                return await QueryBuilder(ctx, expression).AnyAsync();
            }
        }

        public int Delete<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                var set = ctx.Set<TEntity>();
                set.Attach(entity);
                set.Remove(entity);
                return ctx.SaveChanges();
            }
        }

        public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (var ctx = DbContextFactory.CreateContext())
            {
                var set = ctx.Set<TEntity>();
                ctx.Attach(entity);
                ctx.Remove(entity);
                return await ctx.SaveChangesAsync();
            }
        }
    }
}
