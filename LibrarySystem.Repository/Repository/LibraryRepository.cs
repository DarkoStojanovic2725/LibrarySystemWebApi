using LibrarySystem.Repository.Context;
using LibrarySystem.Repository.Repository.Generics;

namespace LibrarySystem.Repository.Repository
{
    public class LibraryRepository : GenericRepository<LibrarySystemDbContext>, ILibraryRepository
    {
        private readonly ILibraryDbContextFactory _contextFactory;
        protected override IDbContextFactory<LibrarySystemDbContext> DbContextFactory => _contextFactory;

        public LibraryRepository(ILibraryDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //Implement specific non-generic methods here
    }
}
