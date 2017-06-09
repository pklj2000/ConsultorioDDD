using Consultorio.Common;
using Consultorio.Common.Validations;
using System;

namespace Consultorio.Domain.Models
{
    public class Atendimento: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int DepartamentoId { get; set; }
        public int CargoId { get; set; }
        public int FuncionarioId { get; set; }
        public int TipoExameId { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }
        public DateTime DataAtendimento { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Funcionario Funcionario {get; set;}
        public virtual TipoExame TipoExame { get; set; }
        #endregion

        #region ctor
        public Atendimento()
        {
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.EmpresaId, "O campo empresa é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.DepartamentoId, "O campo departamento é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.CargoId, "O campo cargo é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.FuncionarioId, "O campo funcionário é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.TipoExameId, "O campo tipo do exame é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.Ativo, "O campo ativo do exame é obrigatório");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
        }
        #endregion
    }
}
