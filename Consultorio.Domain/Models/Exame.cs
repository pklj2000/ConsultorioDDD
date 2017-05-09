using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Exame: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int EmiteSolicitacaoExame { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; }}
        public virtual ICollection<Periodicidade> Periodicidade { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}
