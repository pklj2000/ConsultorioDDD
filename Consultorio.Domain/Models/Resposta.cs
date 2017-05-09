namespace Consultorio.Domain.Models
{
    public class Resposta:  ModelBase
    {
        public int Id { get; set; }
        public int PerguntaId { get; set; }
        public int ProntuarioId { get; set; }
        public string PerguntaDescricao { get; set; }
        public int TipoPerguntaId { get; set; }
        public string RespostaValor { get; set; }
        public string RespostaObservacao { get; set; }
        public int GrupoId { get; set; }
        public int GrupoSequencia { get; set; }

        public virtual Prontuario Prontuario { get; set; }
        public virtual Pergunta Pergunta { get; set; }
    }
}
