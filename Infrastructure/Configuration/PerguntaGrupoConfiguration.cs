using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data.Configuration
{
    public class PerguntaGrupoConfiguration : EntityTypeConfiguration<PerguntaGrupo>
    {
        public PerguntaGrupoConfiguration()
        {
            ToTable("PerguntaGrupo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.Sequencia).IsRequired();
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.AtivoCheck);
        }
    }
}
