using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Contracts;
using UsuariosCoink.Infrastructure.Context;

namespace UsuariosCoink.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly IDbContext _dbContext;
        public Repository(IDbContext context)
        {
            _dbContext = context;
        }
        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

    }
}
