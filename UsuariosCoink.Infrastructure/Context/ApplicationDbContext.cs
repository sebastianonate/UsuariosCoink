using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.Entity;
using UsuariosCoink.Core.Domain;

namespace UsuariosCoink.Infrastructure.Context
{
    [DbConfigurationType(typeof(NpgSqlConfiguration))]
    public class ApplicationDbContext : DbContextBase 
    {
        public ApplicationDbContext(IConfiguration configuration)
            : base(GenericDbConnection.CreateConnection(Providers.Postgress, configuration.GetConnectionString("Default")))
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } 
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id).ToTable(@"Usuarios");
            modelBuilder.Entity<Pais>().HasKey(x => x.Id).ToTable(@"Paises"); ;
            modelBuilder.Entity<Departamento>().HasKey(x => x.Id).ToTable(@"Departamentos"); ;
            modelBuilder.Entity<Municipio>().HasKey(x => x.Id).ToTable(@"Municipios"); ;
        }
    }
}