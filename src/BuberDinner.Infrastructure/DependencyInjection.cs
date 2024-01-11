using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Infrastructure.AppSettings;
using BuberDinner.Infrastructure.Persistence.EFCore.Context;
using BuberDinner.Infrastructure.Persistence.EFCore.Interceptors;
using BuberDinner.Infrastructure.Persistence.EFCore.Repositories;
using BuberDinner.Infrastructure.Persistence.Memory.Repositories;
using BuberDinner.Infrastructure.Persistence.MongoDB.Configurations;
using BuberDinner.Infrastructure.Persistence.MongoDB.Context;
using BuberDinner.Infrastructure.Persistence.MongoDB.Repositories;
using BuberDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        //services.AddSql(configuration);
        services.AddMongo(configuration);
        //services.AddInMemory(configuration);

        return services;
    }

    public static IServiceCollection AddSql(this IServiceCollection services, ConfigurationManager configuration)
    {
        var settings = new SqlServerSettings();
        configuration.Bind(SqlServerSettings.SectionName, settings);

        services.AddSingleton(Options.Create(settings));

        services.AddDbContext<EFCoreDbContext>(options =>
            options.UseSqlServer(settings.ConnectionString));

        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IDinnerRepository, DinnerRepository>();

        return services;
    }

    public static IServiceCollection AddMongo(this IServiceCollection services, ConfigurationManager configuration)
    {
        var settings = new MongoSettings();
        configuration.Bind(MongoSettings.SectionName, settings);

        services.AddSingleton(Options.Create(settings));
        services.AddSingleton<MongoDbContext>();

        services.AddScoped<IUserRepository, UserMongoRepository>();
        services.AddScoped<IMenuRepository, MenuMongoRepository>();
        services.AddScoped<IDinnerRepository, DinnerMongoRepository>();

        return services;
    }

    public static IServiceCollection AddInMemory(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserInMemoryRepository>();
        services.AddScoped<IMenuRepository, MenuInMemoryRepository>();
        services.AddScoped<IDinnerRepository, DinnerInMemoryRepository>();

        return services;
    }
}