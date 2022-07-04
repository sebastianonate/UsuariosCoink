using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain;
using UsuariosCoink.Core.Domain.Contracts;
using UsuariosCoink.Infrastructure.Context;

namespace UsuariosCoink.Infrastructure.Persistence
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IDbContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Usuario, Municipio, Departamento, Pais, Usuario>(
                "GetUsuarioById", (u, m, d, p) =>
                {
                    u.Municipio = m;
                    u.Municipio.Departamento = d;
                    u.Municipio.Departamento.Pais = p;
                    return u;
                },
                param: new { usuarioid = id },
                commandType: CommandType.StoredProcedure,
                splitOn: "municipio_Id,departamento_Id,pais_Id"
                )).FirstOrDefault();
        }

        public async Task<List<Usuario>> ListAsync(CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Usuario, Municipio, Departamento, Pais, Usuario>(
                 "GetAllUsuarios", (u, m, d, p) =>
                 {
                     u.Municipio = m;
                     u.Municipio.Departamento = d;
                     u.Municipio.Departamento.Pais = p;
                     return u;
                 },
                 commandType: CommandType.StoredProcedure,
                 splitOn: "municipio_Id,departamento_Id,pais_Id"
                 )).ToList();
        }
    }
}
