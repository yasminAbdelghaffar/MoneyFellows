using Application.Commands.Login;
using Application.Commands.Orders;
using Application.Commands.Products;
using Application.Commands.RegisterUser;
using Application.Queries.Order;
using Application.Queries.Product;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validators;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API
{
    public static class IoC
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterAdminCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllOrdersQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetOrderByIdQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddOrderCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateOrderCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteOrderCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetProductByIdQuery>());
            services.AddScoped<IPasswordHasher, PasswordHasher> ();
            services.AddScoped<ITokenService, TokenService>();
            services.AddValidatorsFromAssemblyContaining<OrderValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
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
