using BookStore.Business.MappingProfiles;
using BookStore.Business.Services;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using BookStore.Data.Repositories.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database Configuration
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // AutoMapper Configuration
        services.AddAutoMapper(typeof(BookMappingProfile), 
            typeof(CategoryMappingProfile), 
            typeof(UserMappingProfile), 
            typeof(ReviewMappingProfile), 
            typeof(CartMappingProfile), 
            typeof(OrderMappingProfile));

        // CORS Configuration
        services.AddCors();

        // Identity Configuration
        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        // JWT Configuration
        services.AddJwtAuthentication(configuration);

        // Repository Dependencies
        services.AddRepositories();

        // Service Dependencies
        services.AddApplicationServices();

        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = Encoding.ASCII.GetBytes(configuration["JwtSettings:SecretKey"]!);
        var issuer = configuration["JwtSettings:Issuer"]!;
        var audience = configuration["JwtSettings:Audience"]!;

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateLifetime = true
            };
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
        services.AddScoped(typeof(ICartItemRepository), typeof(CartItemRepository));
        services.AddScoped(typeof(ICartRepository), typeof(CartRepository));
        services.AddScoped(typeof(IOrderItemRepository), typeof(OrderItemRepository));
        services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<BookService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<TokenService>();
        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<ReviewService>();
        services.AddScoped<CartService>();
        services.AddScoped<OrderService>();

        return services;
    }
} 