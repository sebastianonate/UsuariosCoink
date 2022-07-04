using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Contracts;
using UsuariosCoink.Infrastructure.Context;

namespace UsuariosCoink.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {


        private readonly IDbContext _context;
        public UnitOfWork(IDbContext context) => _context = context;


        private IUsuarioRepository _usuarioRepository;
        public IUsuarioRepository UsuarioRepository { get { return _usuarioRepository ??= new UsuarioRepository(_context); } }

        private IDepartamentoRepository _departamentoRepository;
        public IDepartamentoRepository DepartamentoRepository { get { return _departamentoRepository ??= new DepartamentoRepository(_context); }}

        private IPaisRepository _paisRepository;
        public IPaisRepository PaisRepository { get { return _paisRepository ??= new PaisRepository(_context); } }

        private IMunicipioRepository _municipioRepository;
        public IMunicipioRepository MunicipioRepository { get { return _municipioRepository ??= new MunicipioRepository(_context); } }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}
