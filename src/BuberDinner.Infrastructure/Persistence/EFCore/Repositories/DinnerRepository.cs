using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using BuberDinner.Infrastructure.Persistence.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Repositories;

public class DinnerRepository : IDinnerRepository
{
    private readonly EFCoreDbContext _dbContext;

    public DinnerRepository(EFCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Dinner menu)
    {
        await _dbContext.Dinners.AddAsync(menu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Dinner?> GetByIdAsync(string id)
    {
        return await _dbContext.Dinners.SingleOrDefaultAsync(dinner => dinner.Id == DinnerId.Create(id));
    }

    public async Task<IEnumerable<Dinner>> ListUserDinnerAsync(string userId)
    {
        await Task.CompletedTask;
        return _dbContext.Dinners
            .Where(dinner => dinner.Host.UserId == UserId.Create(userId))
            .AsEnumerable();
    }
}
