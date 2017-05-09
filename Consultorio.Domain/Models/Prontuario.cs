using Consultorio.Common.Validations;
using System;

namespace Consultorio.Domain.Models
{
    public class Prontuario: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public int AtendimentoId { get; set; }
        public int TipoExameId { get; set; }
        public int EmpresaId { get; set; }
        public int DepartamentoId { get; set; }
        public int CargoId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataExame { get; set; }
        public int ResultadoClinicoId { get; set; }
        public int ResultadoProntuarioId { get; set; }
        public int ProfissionalId { get; set; }
        public int EstadoCivilId { get; set; }
        public int ASO { get; set; }
        public string AsoObservacao { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual TipoExame TipoExame { get; set; }

        public ResultadoClinico ResultadoClinico { get; set; }
        public ResultadoProntuario ResultadoProntuario { get; set; }
        #endregion

        #region ctor
        public Prontuario()
        {
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
            this.DataExame = DateTime.Now;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.AtendimentoId, "Código do atendimento não configurado para o prontuário");
            AssertionConcern.AssertArgumentNotNull(this.TipoExameId, "Tipo do Exame não configurado para o prontuário");
            AssertionConcern.AssertArgumentNotNull(this.EmpresaId, "Empresa não configurado para o prontuário");
            AssertionConcern.AssertArgumentNotNull(this.DepartamentoId, "Departamento não configurado para o prontuário");
            AssertionConcern.AssertArgumentNotNull(this.CargoId, "Cargo não configurado para o prontuário");
            AssertionConcern.AssertArgumentNotNull(this.FuncionarioId, "Funcionário não configurado para o prontuário");
            AssertionConcern.AssertArgumentNotNull(this.EstadoCivilId, "Estado Civil do Funcionário não configurado para o prontuário");
        }
        #endregion  
    }
}
