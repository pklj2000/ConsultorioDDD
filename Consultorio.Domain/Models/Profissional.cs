namespace Consultorio.Domain.Models
{
    public class Profissional:ModelBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Telefone { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }
        public string Observacao { get; set; }
    }
}
