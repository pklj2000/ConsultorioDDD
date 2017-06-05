using Consultorio.Common.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Consultorio.Domain.Models
{
    public class Funcionario : ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public int DepartamentoId { get; set; }
        public int CargoId { get; set; }
        public int EstadoCivilId { get; set; }
        public int SituacaoFuncionarioId { get; set; }
        public int PeriodicidadeId { get; set; }
        public string Rg { get; set; }
        public string Sexo { get; set; }
        public string CargoAnterior { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataNascimento { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataAdmissao { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataUltimoExame { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataDemissao { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }

        public virtual Empresa Empresa { get; set; }
        public virtual Departamento Departamento { get; set;}
        public virtual Cargo Cargo { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual SituacaoFuncionario SituacaoFuncionario { get; set; }
        public virtual Periodicidade Periodicidade { get; set; }
        #endregion

        #region ctor
        public Funcionario()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Ativo = 1;
        }
        #endregion

        #region mothods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, "O campo Nome é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Nome,200, "O campo Nome deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentNotNull(this.EmpresaId, "O campo Empresa é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.DepartamentoId, "O campo Departamento é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.CargoId, "O campo Cargo é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.SituacaoFuncionarioId, "O campo Situação é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.EstadoCivilId, "O campo Estado Cívil é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.PeriodicidadeId, "O campo Periodicidade é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.Sexo, "O campo Sexo é obrigatório");
            AssertionConcern.AssertArgumentMatches("^(?:F|M)$", this.Sexo, "O campo Sexo é inválido");
            AssertionConcern.AssertArgumentNotNull(this.Rg, "O campo RG é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.Ativo, "O campo Ativo é obrigatório");
        }
        #endregion
    }
}
