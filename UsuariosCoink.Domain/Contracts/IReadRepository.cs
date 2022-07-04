using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosCoink.Core.Domain.Contracts
{
    public interface IReadRepository<T> where T : IEntity
    {
        Task<T?> GetAsync<TId>(TId id, CancellationToken cancellationToken = default);
        Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
    }
}
