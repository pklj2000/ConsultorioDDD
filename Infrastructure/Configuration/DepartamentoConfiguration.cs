using System.Data.Entity.ModelConfiguration;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Configuration
{
    class DepartamentoConfiguration: EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
        {
            ToTable("Departamento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);
        }
    }
}
