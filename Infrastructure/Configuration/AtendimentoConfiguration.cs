using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Consultorio.Data.Configuration
{
    public class AtendimentoConfiguration : EntityTypeConfiguration<Atendimento>
    {
        public AtendimentoConfiguration()
        {
            ToTable("Atendimento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.DepartamentoId).IsRequired();
            Property(x => x.CargoId).IsRequired();
            Property(x => x.FuncionarioId).IsRequired();
            Property(x => x.TipoExameId).IsRequired();
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);

            HasRequired(x => x.Empresa)
                .WithMany()
                .HasForeignKey(x => x.EmpresaId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Departamento)
                .WithMany()
                .HasForeignKey(x => x.DepartamentoId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Cargo)
                .WithMany()
                .HasForeignKey(x => x.CargoId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Funcionario)
                .WithMany()
                .HasForeignKey(x => x.FuncionarioId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.TipoExame)
                .WithMany()
                .HasForeignKey(x => x.TipoExameId)
                .WillCascadeOnDelete(false);
        }
    }
}
