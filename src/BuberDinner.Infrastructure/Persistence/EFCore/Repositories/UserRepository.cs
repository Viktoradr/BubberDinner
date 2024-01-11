using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using BuberDinner.Infrastructure.Persistence.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EFCoreDbContext _dbContext;

    public UserRepository(EFCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == UserId.Create(id));
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
}
