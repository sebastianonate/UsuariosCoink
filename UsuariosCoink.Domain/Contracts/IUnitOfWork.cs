using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosCoink.Core.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IDepartamentoRepository DepartamentoRepository { get; }
        IPaisRepository PaisRepository { get; }
        IMunicipioRepository MunicipioRepository { get; }
        Task<int> CommitAsync();
    }
}
