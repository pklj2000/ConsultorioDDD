using Consultorio.Common.Validations;
using System;

namespace Consultorio.Domain.Models
{
    public class EstadoCivil: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }
        #endregion

        #region ctor
        public EstadoCivil()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Ativo = 1;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Estado Civil é obrigatório");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, "O campo ativo está fora do range 0/1");
        }
        #endregion
    }
}
