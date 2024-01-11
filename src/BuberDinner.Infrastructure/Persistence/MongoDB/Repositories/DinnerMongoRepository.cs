using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.DinnerAggregate;

namespace BuberDinner.Infrastructure.Persistence.MongoDB.Repositories;

public class DinnerMongoRepository : IDinnerRepository
{
    public Task AddAsync(Dinner menu)
    {
        throw new NotImplementedException();
    }

    public Task<Dinner?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Dinner>> ListUserDinnerAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
