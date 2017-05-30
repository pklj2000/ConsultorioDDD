using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Consultorio.Data.Configuration
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            ToTable("Funcionario");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired();
            Property(x => x.Nome).HasMaxLength(200);
            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.DepartamentoId).IsRequired();
            Property(x => x.CargoId).IsRequired();
            Property(x => x.PeriodicidadeId).IsRequired();
            Property(x => x.SituacaoFuncionarioId).IsRequired();
            Property(x => x.EstadoCivilId).IsRequired();
            Property(x => x.Rg).IsRequired();
            Property(x => x.Ativo).IsRequired();
            Property(x => x.AddedDate).IsRequired();
            Property(x => x.ModifiedDate).IsRequired();
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

            HasRequired(x => x.EstadoCivil)
                .WithMany()
                .HasForeignKey(x => x.EstadoCivilId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.SituacaoFuncionario)
                .WithMany()
                .HasForeignKey(x => x.SituacaoFuncionarioId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Periodicidade)
                .WithMany()
                .HasForeignKey(x => x.PeriodicidadeId)
                .WillCascadeOnDelete(false);
        }
    }
}
