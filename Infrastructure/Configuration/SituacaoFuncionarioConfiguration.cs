using Consultorio.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Consultorio.Data.Configuration
{
    class SituacaoFuncionarioConfiguration : EntityTypeConfiguration<SituacaoFuncionario>
    {
        public SituacaoFuncionarioConfiguration()
        {
            ToTable("SituacaoFuncionario");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Descricao).HasMaxLength(200);
            Property(x => x.Ativo).IsRequired();
            Property(x => x.AddedDate).IsRequired();
            Property(x => x.ModifiedDate).IsRequired();
            Ignore(x => x.AtivoCheck);
        }
    }
}
