using System.Data.Entity.ModelConfiguration;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Configuration
{
    public class EmpresaConfiguration: EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            ToTable("Empresa");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired().HasMaxLength(200);
            Property(x => x.Cidade).HasMaxLength(200);
            Ignore(x => x.AtivoCheck);
        }
    }
}
