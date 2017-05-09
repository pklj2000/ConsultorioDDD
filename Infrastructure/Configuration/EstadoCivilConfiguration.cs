using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;


namespace Consultorio.Data.Configuration
{
    class EstadoCivilConfiguration: EntityTypeConfiguration<EstadoCivil>
    {
        public EstadoCivilConfiguration()
        {
            ToTable("EstadoCivil");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Ignore(x => x.AtivoCheck);
        }
    }
}
