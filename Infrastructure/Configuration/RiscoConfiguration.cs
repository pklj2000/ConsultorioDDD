using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Consultorio.Data.Configuration
{
    public class RiscoConfiguration : EntityTypeConfiguration<Risco>
    {
        public RiscoConfiguration()
        {
            ToTable("Risco");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);
        }
    }
}
