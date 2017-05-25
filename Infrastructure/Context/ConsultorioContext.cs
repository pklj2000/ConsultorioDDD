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
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Risco> Riscos { get; set; }
        public DbSet<Periodicidade> Periodicidade { get; set; }
        public DbSet<Exame> Exames { get; set; }

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
            modelBuilder.Configurations.Add(new TransacaoConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new RiscoConfiguration());
            modelBuilder.Configurations.Add(new PeriodicidadeConfiguration());
            modelBuilder.Configurations.Add(new ExameConfiguration());

            //Usuario x Perfil 
            modelBuilder.Entity<Usuario>()
                .HasMany<Perfil>(p => p.Perfis)
                .WithMany(u => u.Usuarios)
                .Map(pu =>
                {
                    pu.MapLeftKey("UsuarioId");
                    pu.MapRightKey("PerfilId");
                    pu.ToTable("UsuarioPerfil");
                });

            //Perfil x Transacao
            modelBuilder.Entity<Perfil>()
                .HasMany<Transacao>(t => t.Transacao)
                .WithMany(p => p.Perfis)
                .Map(tp =>
                {
                    tp.MapLeftKey("PerfilId");
                    tp.MapRightKey("TransacaoId");
                    tp.ToTable("PerfilTransacao");
                });

            //Exame x TipoExame
            modelBuilder.Entity<Exame>()
                .HasMany<TipoExame>(t => t.TipoExame)
                .WithMany(e => e.Exame)
                .Map(te =>
                {
                    te.MapLeftKey("ExameId");
                    te.MapRightKey("TipoExameId");
                    te.ToTable("ExameTipoExame");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
