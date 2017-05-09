using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Periodicidade: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Dias { get; set; }
        public virtual ICollection<Exame> Exames { get; set; }
    }
}
