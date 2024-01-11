using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using BuberDinner.Infrastructure.Persistence.MongoDB.Context;
using MongoDB.Driver;

namespace BuberDinner.Infrastructure.Persistence.MongoDB.Repositories;

public class UserMongoRepository : IUserRepository
{
    private readonly MongoDbContext _dbContext;

    //https://www.mongodb.com/docs/drivers/csharp/current/quick-reference/#std-label-csharp-quick-reference

    //https://www.red-gate.com/simple-talk/development/dotnet-development/how-to-program-with-mongodb-using-the-net-driver/

    public UserMongoRepository(MongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.InsertOneAsync(user);
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        var filter = Builders<User>.Filter.Eq(user => user.Id, UserId.Create(id));

        return await _dbContext.Users.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var filter = Builders<User>.Filter.Eq(user => user.Email, email);

        return await _dbContext.Users.Find(filter).FirstOrDefaultAsync();
    }
}
