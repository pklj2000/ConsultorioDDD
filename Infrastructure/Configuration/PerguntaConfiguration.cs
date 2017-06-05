using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Consultorio.Data.Configuration
{
    public class PerguntaConfiguration : EntityTypeConfiguration<Pergunta>
    {
        public PerguntaConfiguration()
        {
            ToTable("Pergunta");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.PerguntaGrupoId).IsRequired();
            Property(x => x.TipoRespostaId).IsRequired();
            Property(x => x.RespostaObrigatoria).IsRequired();
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);

            HasRequired(x => x.PerguntaGrupo)
                .WithMany()
                .HasForeignKey(x => x.PerguntaGrupoId)
                .WillCascadeOnDelete(false);
        }
    }
}
