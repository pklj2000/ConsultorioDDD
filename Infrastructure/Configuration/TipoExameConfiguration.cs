using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Data.Configuration
{
    class TipoExameConfiguration: EntityTypeConfiguration<TipoExame>
    {
        public TipoExameConfiguration()
        {
            ToTable("TipoExame");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.AddedDate).IsRequired();
            Property(x => x.ModifiedDate).IsRequired();
            Property(x => x.UsuarioId).IsRequired();
            Ignore(x => x.AtivoCheck);
        }
    }
}