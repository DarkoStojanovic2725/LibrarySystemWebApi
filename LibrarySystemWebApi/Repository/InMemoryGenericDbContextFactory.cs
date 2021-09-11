using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystemWebApi.Context;

namespace LibrarySystemWebApi.Repository
{
    public class InMemoryGenericDbContextFactory : ILibraryDbContextFactory
    {
        public LibrarySystemDbContext CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}
