using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Consultorio.Data.Configuration
{
    public class ProfissionalConfiguration : EntityTypeConfiguration<Profissional>
    {
        public ProfissionalConfiguration()
        {
            ToTable("Profissional");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired();
            Property(x => x.Nome).HasMaxLength(200);
            Property(x => x.CRM).IsRequired();
            Property(x => x.CRM).HasMaxLength(20);
            Property(x => x.Telefone).HasMaxLength(200);
            Property(x => x.Telefone).HasMaxLength(500);
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);
        }
    }
}
