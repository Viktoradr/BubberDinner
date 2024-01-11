using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Memory.Repositories;

public class DinnerInMemoryRepository : IDinnerRepository
{
    private static readonly List<Dinner> _dinners = new();

    public async Task AddAsync(Dinner menu)
    {
        await Task.CompletedTask;

        _dinners.Add(menu);
    }

    public async Task<Dinner?> GetByIdAsync(string id)
    {
        await Task.CompletedTask;

        return _dinners.SingleOrDefault(x => x.Id == DinnerId.Create(id));
    }

    public async Task<IEnumerable<Dinner>> ListUserDinnerAsync(string userId)
    {
        await Task.CompletedTask;
        return _dinners.Where(x => x.HostId == HostId.Create(userId)).AsEnumerable();
    }
}
