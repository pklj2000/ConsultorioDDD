using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Pergunta: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Sequencia { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }
        public int PerguntaGrupoId { get; set; }
        public int TipoRespostaId { get; set; }
        public int RespostaObrigatoria { get; set; }
        public string RespostaItem { get; set; }

        public virtual PerguntaGrupo PerguntaGrupo { get; set; }
        public Dictionary<int, string> TipoResposta { get; set; }
    }
}
