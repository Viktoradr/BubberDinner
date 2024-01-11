using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Memory.Repositories;

public class UserInMemoryRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public async Task AddAsync(User user)
    {
        await Task.CompletedTask;

        _users.Add(user);
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Id == UserId.Create(id));
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Email == email);
    }
}
