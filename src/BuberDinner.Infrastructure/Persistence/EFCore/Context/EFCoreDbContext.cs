using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Infrastructure.Persistence.EFCore.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Context;

public class EFCoreDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<Dinner> Dinners { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(EFCoreDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

}
