using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain;
using UsuariosCoink.Core.Domain.Contracts;
using UsuariosCoink.Infrastructure.Context;

namespace UsuariosCoink.Infrastructure.Persistence
{
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(IDbContext context) : base(context)
        {
        }

        public async Task<Municipio?> GetAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Municipio>("GetMunicipioById", param: new { municipioid = id }, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();

        }

        public async Task<Municipio?> GetMunicipioByDptoAndNombre(int departamentoId, string nombre)
        {
            return (await _dbContext.QueryAsync<Municipio>("GetMunicipioByDptoAndName", param: new { nombre, departamentoid = departamentoId }, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();

        }

        public async Task<List<Municipio>> ListAsync(CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Municipio>("GetAllMunicipios", commandType: System.Data.CommandType.StoredProcedure)).ToList();

        }
    }
}
