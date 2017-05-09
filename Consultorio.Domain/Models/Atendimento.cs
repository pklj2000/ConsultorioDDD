using System;

namespace Consultorio.Domain.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int FuncionarioId { get; set; }
        public int TipoExameId { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }
        public DateTime DataAtendimento { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual TipoExame TipoExame { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
