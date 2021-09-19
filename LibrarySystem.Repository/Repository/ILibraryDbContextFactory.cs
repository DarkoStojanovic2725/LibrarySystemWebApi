using LibrarySystem.Repository.Context;
using LibrarySystem.Repository.Repository.Generics;

namespace LibrarySystem.Repository.Repository
{
    public interface ILibraryDbContextFactory : IDbContextFactory<LibrarySystemDbContext>
    {
    }
}
