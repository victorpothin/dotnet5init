using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Services;
using Data.Repositories;
using Data.Contexts;


namespace Ioc
{
     public class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<UserService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            services.Scan(scan => scan
                .FromAssemblyOf<UserRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("memoryDatabase"));
        }
    }
}