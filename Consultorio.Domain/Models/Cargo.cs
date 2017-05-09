using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Cargo: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int DepartamentoId { get; set; }
        public int EmpresaId { get; set; }
        public int PeriodicidadeId { get; set; }

        public virtual Periodicidade Periodicidade { get; set; }

        public virtual ICollection<Exame> Exames { get; set; }
        public virtual ICollection<Risco> Riscos { get; set; }
    }
}
