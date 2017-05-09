using System;

namespace Consultorio.Domain.Models
{
    public class Funcionario: ModelBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public int CargoId { get; set; }
        public int EstadoCivilId { get; set; }
        public int SituacaoId { get; set; }
        public int PeriodicidadeId { get; set; }
        public string Rg { get; set; }
        public string Sexo { get; set; }
        public string CargoAnterior { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataUltimoExame { get; set; }
        public DateTime DataDemissao { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }

        public virtual Cargo Cargo { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual Periodicidade Periodicidade { get; set; }
    }
}
