using System.Data.Entity;
using Consultorio.Domain.Models;
using Consultorio.Data.Configuration;

namespace Consultorio.Data.Context
{
    public class ConsultorioContext: DbContext
    {
        public ConsultorioContext() : base("name=ConsultorioConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<TipoExame> TipoExame { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new TipoExameConfiguration());
            modelBuilder.Configurations.Add(new EstadoCivilConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
