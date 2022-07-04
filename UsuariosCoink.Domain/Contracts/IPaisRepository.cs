using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain;

namespace UsuariosCoink.Core.Domain.Contracts
{
    public interface IPaisRepository : IRepository<Pais>, IReadRepository<Pais>
    {
        Task<Pais?> GetPaisByNombreAsync(string nombre);
    }
}

