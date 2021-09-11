using LibrarySystemWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWebApi.Context
{
    public class LibrarySystemDbContext : DbContext
    {
        public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
