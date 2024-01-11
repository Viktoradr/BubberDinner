using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence.Memory.Repositories;

public class MenuInMemoryRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    public async Task AddAsync(Menu menu)
    {
        await Task.CompletedTask;

        _menus.Add(menu);
    }
    //public IEnumerable<Menu> GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //public ValueTask Add(Menu menu)
    //{
    //    s_menus.Add(menu);
    //    return ValueTask.CompletedTask;
    //}
    //public ValueTask Update(Menu menu)
    //{
    //    throw new NotImplementedException();
    //}

    //public ValueTask Delete(Menu menu)
    //{
    //    throw new NotImplementedException();
    //}

    //public ValueTask<Menu?> FindById(string id) =>
    //    throw new NotImplementedException();
}
