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
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<SituacaoFuncionario> SituacaoFucionario { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

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
            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new SituacaoFuncionarioConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());

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

            //Cargo x Exames
            modelBuilder.Entity<Cargo>()
                .HasMany<Exame>(e => e.Exames)
                .WithMany(c => c.Cargo)
                .Map(ce =>
                {
                    ce.MapLeftKey("CargoId");
                    ce.MapRightKey("ExameId");
                    ce.ToTable("CargoExame");
                });

            //Cargo x Riscos
            modelBuilder.Entity<Cargo>()
                .HasMany<Risco>(r => r.Riscos)
                .WithMany(c => c.Cargo)
                .Map(cr =>
                {
                    cr.MapLeftKey("CargoId");
                    cr.MapRightKey("RiscoId");
                    cr.ToTable("CargoRisco");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
