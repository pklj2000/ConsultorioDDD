using Consultorio.Common;
using Consultorio.Common.Validations;
using System;

namespace Consultorio.Domain.Models
{
    public class Profissional:ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Telefone { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }
        public string Observacao { get; set; }
        #endregion

        #region ctor
        public Profissional()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Ativo = 1;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, "O campo Nome é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Nome, 200, "O campo Nome deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentNotNull(this.CRM, "O campo CRM é obrigatório");
            AssertionConcern.AssertArgumentLength(this.CRM, 20, "O campo CRM deve conter até 20 caracteres");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
        }
        #endregion
    }
}
