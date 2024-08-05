using Application.Services;
using Application.Services.Interfaces;
using Core.DTOs.Registration;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API
{
    public static class IoC
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            services.AddScoped<IPasswordHasher<RegisterationUser>, PasswordHasher <RegisterationUser>> ();
            services.AddScoped<ITokenService, TokenService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static IServiceCollection RegisterPostgressDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddEntityFrameworkNpgsql().AddDbContextPool<ApplicationDBContext>(opts => opts.UseLazyLoadingProxies(false)
           .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
           .UseNpgsql(config["PostgressConnectionString"],
           options => options.EnableRetryOnFailure(maxRetryCount: 4, maxRetryDelay: TimeSpan.FromSeconds(2), errorCodesToAdd: null)));
            return services;
        }
    }
}
