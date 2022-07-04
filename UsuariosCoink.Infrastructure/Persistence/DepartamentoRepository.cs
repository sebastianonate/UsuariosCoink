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
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(IDbContext context) : base(context)
        {
        }

        public async Task<Departamento?> GetAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Departamento>("GetDepartamentoById", param: new { departamentoid = id }, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
        }

        public async Task<Departamento?> GetDepartamentoByPaisAndNombre(int paisId, string nombre)
        {
            return (await _dbContext.QueryAsync<Departamento>("GetDptoByPaisAndName", param: new { nombre, paisid = paisId, }, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
        }

        public async Task<List<Departamento>> ListAsync(CancellationToken cancellationToken = default)
        {
            return (await _dbContext.QueryAsync<Departamento>("GetAllDepartamentos", commandType: System.Data.CommandType.StoredProcedure)).ToList();

        }
    }
}
