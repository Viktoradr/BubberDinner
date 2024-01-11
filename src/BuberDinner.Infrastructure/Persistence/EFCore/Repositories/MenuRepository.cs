using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Infrastructure.Persistence.EFCore.Context;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Repositories;

public class MenuRepository : IMenuRepository
{
    //private static readonly List<Menu> _menus = new();

    private readonly EFCoreDbContext _dbContext;

    public MenuRepository(EFCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Menu menu)
    {
        await _dbContext.Menus.AddAsync(menu);
        await _dbContext.SaveChangesAsync();
    }
}
