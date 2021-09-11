using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWebApi.Repository.Generics
{
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext CreateContext();
    }
}
