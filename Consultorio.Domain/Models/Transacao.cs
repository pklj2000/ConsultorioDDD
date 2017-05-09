using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Transacao: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Janela { get; set; }
        public string Objeto { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }
        public int ModuloId { get; set; }

        public virtual ICollection<Perfil> Perfil { get; set; }
    }
}
