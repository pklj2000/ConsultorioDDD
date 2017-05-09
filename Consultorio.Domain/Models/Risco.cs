using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Risco: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}
