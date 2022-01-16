using LibrarySystem.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Repository.DependencyRegistry
{
    public class RepositoryDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<ILibraryDbContextFactory, InMemoryGenericDbContextFactory>();
            services.AddTransient<ILibraryRepository, LibraryRepository>();
        }
    }
}
