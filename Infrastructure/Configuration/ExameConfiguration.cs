using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Consultorio.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data.Configuration
{
    public class ExameConfiguration: EntityTypeConfiguration<Exame>
    {
        public ExameConfiguration()
        {
            ToTable("Exame");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.Ativo).IsRequired();
            Property(x => x.EmitePorPeriodicidade).IsRequired();
            Property(x => x.EmiteSolicitacaoExame).IsRequired();
            Ignore(x => x.AtivoCheck);
            Ignore(x => x.EmiteSolicitacaoExameCheck);
            Ignore(x => x.EmitePorPeriodicidadeCheck);
        }
    }
}
