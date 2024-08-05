using Application.Services;
using Application.Services.Interfaces;
using Core.DTOs.Registration;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

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
    }
}
