using System.Data.Entity.ModelConfiguration;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Configuration
{
    public class UsuarioConfiguration: EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired();
            Property(x => x.Nome).HasMaxLength(200);
            Ignore(x => x.AtivoCheck);
        }
    }
}
