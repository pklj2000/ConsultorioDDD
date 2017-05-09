namespace Consultorio.Domain.Models
{
    public class PerguntaGrupo: ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Sequencia { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }

    }
}
