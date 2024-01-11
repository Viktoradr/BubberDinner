using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(CancellationToken cancellationToken);
    ValueTask Add(T entity, CancellationToken cancellationToken);
    ValueTask Update(T entity, CancellationToken cancellationToken);
    ValueTask Delete(T entity, CancellationToken cancellationToken);
    ValueTask<T?> FindById(string id, CancellationToken cancellationToken);
}
