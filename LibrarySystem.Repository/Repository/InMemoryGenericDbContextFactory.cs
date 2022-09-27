using LibrarySystem.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibrarySystem.Repository.Repository
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
            var context = new LibrarySystemDbContext(builder.Options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
