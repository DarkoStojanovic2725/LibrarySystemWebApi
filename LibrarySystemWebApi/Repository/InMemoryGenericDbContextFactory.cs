using LibrarySystemWebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibrarySystemWebApi.Repository
{
    public class InMemoryGenericDbContextFactory : ILibraryDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public InMemoryGenericDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LibrarySystemDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<LibrarySystemDbContext>();
            builder.UseInMemoryDatabase(_configuration.GetConnectionString("InMemoryConnection"));
            return new LibrarySystemDbContext(builder.Options);
        }
    }
}
