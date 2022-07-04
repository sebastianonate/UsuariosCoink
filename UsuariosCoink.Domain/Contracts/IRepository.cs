using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosCoink.Core.Domain.Contracts
{
    public interface IRepository<T> where T : IEntity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

    }
}
