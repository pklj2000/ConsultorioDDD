using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Perfil: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }
        public int ModuloId { get; set; }

        public virtual ICollection<Transacao> Transacao { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
