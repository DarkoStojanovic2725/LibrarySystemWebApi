using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository.Repository.Generics
{
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext CreateContext();
    }
}
