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
    internal class PaisRepository : Repository<Pais>, IPaisRepository
    {
        public PaisRepository(IDbContext context) : base(context)
        {
        }

        public async Task<Pais?> GetAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Pais>("GetPaisById", param: new { paisid = id}, commandType:System.Data.CommandType.StoredProcedure )).FirstOrDefault();
        }

        public async Task<Pais?> GetPaisByNombreAsync(string nombre)
        {
            return (await _dbContext.QueryAsync<Pais>("GetPaisByName", param: new { nombre }, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();

        }

        public async Task<List<Pais>> ListAsync(CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Pais>("GetAllPaises", commandType: System.Data.CommandType.StoredProcedure)).ToList();
        }
    }
}
