using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain;

namespace UsuariosCoink.Core.Domain.Contracts
{
    public interface IMunicipioRepository : IRepository<Municipio>, IReadRepository<Municipio>
    {
        Task<Municipio?> GetMunicipioByDptoAndNombre(int departamentoId, string nombre);
    }
}
