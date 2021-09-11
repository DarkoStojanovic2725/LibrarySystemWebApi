using LibrarySystemWebApi.Context;
using LibrarySystemWebApi.Repository.Generics;

namespace LibrarySystemWebApi.Repository
{
    public class LibraryRepository : GenericRepository<LibrarySystemDbContext>, ILibraryRepository
    {
        private readonly ILibraryDbContextFactory _contextFactory;
        protected override IDbContextFactory<LibrarySystemDbContext> DbContextFactory => _contextFactory;

        public LibraryRepository(ILibraryDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, new()
        //{
        //    using (var ctx = _contextFactory.CreateContext())
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, new()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
