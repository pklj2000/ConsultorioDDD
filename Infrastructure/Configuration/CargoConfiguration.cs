using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Consultorio.Data.Configuration
{
    class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            ToTable("Cargo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.DepartamentoId).IsRequired();
            Property(x => x.PeriodicidadeId).IsRequired();
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);
            Ignore(x => x.ExamesKeys);
            Ignore(x => x.RiscosKeys);

            HasRequired(x => x.Empresa)
                .WithMany()
                .HasForeignKey(x => x.EmpresaId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Departamento)
                .WithMany()
                .HasForeignKey(x => x.DepartamentoId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Periodicidade)
                .WithMany()
                .HasForeignKey(x => x.PeriodicidadeId)
                .WillCascadeOnDelete(false);

        }
    }
}
