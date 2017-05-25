using Consultorio.Common.Validations;
using System;
using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Periodicidade: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Dias { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }
        //public virtual ICollection<Exame> Exames { get; set; }
        #endregion

        #region ctor
        public Periodicidade()
        {
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Descrição é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo Descrição deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentRange(this.Dias, 0, 99999, "A periodicidade deve estar entre 0 e 99999 dias");
            AssertionConcern.AssertArgumentNotNull(this.AddedDate, "Data de inclusão não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.ModifiedDate, "Data da última modificação não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.UsuarioId, "Usuário responsável não preenchido");
        }
        #endregion
    }
}
