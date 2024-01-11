using BuberDinner.Domain.DinnerAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IDinnerRepository
{
    Task AddAsync(Dinner menu);
    Task<Dinner?> GetByIdAsync(string id);
    Task<IEnumerable<Dinner>> ListUserDinnerAsync(string userId);
}
