using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using LibrarySystemWebApi.DataSeed;
using LibrarySystemWebApi.MappingProfiles;
using LibrarySystemWebApi.Middleware;
using LibrarySystemWebApi.Models;
using LibrarySystemWebApi.Repository;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibrarySystemWebApi", Version = "v1" });
            });
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(SharedMappingProfile));

            RegisterDependencies(services);
        }

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<ILibraryDbContextFactory, InMemoryGenericDbContextFactory>();
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IDataSeeder, DataSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibrarySystemWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware(typeof(RestErrorHandlingMiddleware));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Temporary code for inserting initial data
            var service = app.ApplicationServices.GetService<IDataSeeder>();

            service?.SeedData();
        }
    }
}
