using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetByIdAsync(string id);
    Task AddAsync(User user);
}
