using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;


namespace Consultorio.Data.Configuration
{
    class TransacaoConfiguration : EntityTypeConfiguration<Transacao>
    {
        public TransacaoConfiguration()
        {
            ToTable("Transacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.Janela).IsRequired();
            Property(x => x.Janela).HasMaxLength(200);
            Property(x => x.Objeto).HasMaxLength(200);
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);
        }
    }
}
