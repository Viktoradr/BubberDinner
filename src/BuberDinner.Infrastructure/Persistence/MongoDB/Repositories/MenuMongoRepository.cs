using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Infrastructure.Persistence.MongoDB.Context;

namespace BuberDinner.Infrastructure.Persistence.MongoDB.Repositories;

public class MenuMongoRepository : IMenuRepository
{
    private readonly MongoDbContext _dbContext;

    public MenuMongoRepository(MongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Menu menu)
    {
        await _dbContext.Menus.InsertOneAsync(menu);
    }
}
