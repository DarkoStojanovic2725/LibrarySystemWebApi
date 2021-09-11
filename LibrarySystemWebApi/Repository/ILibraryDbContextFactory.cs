using LibrarySystemWebApi.Context;
using LibrarySystemWebApi.Repository.Generics;

namespace LibrarySystemWebApi.Repository
{
    public interface ILibraryDbContextFactory : IDbContextFactory<LibrarySystemDbContext>
    {
    }
}
