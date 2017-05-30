using Consultorio.Common;
using Consultorio.Common.Validations;
using System;

namespace Consultorio.Domain.Models
{
    public class SituacaoFuncionario: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }
        #endregion

        #region ctor
        public SituacaoFuncionario()
        {
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }
        #endregion

        #region mathods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Situação é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo situação deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
        }
        #endregion
    }
}
