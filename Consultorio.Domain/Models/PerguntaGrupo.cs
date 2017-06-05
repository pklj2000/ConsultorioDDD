using System;
using Consultorio.Common;
using Consultorio.Common.Validations;
using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class PerguntaGrupo: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Sequencia { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }

        public virtual ICollection<Pergunta> Perguntas { get; set; }
        #endregion

        #region ctor
        public PerguntaGrupo()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Ativo = 1;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Grupo é obrigatório" );
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo Grupo deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentRange(this.Sequencia, 1, 9999, "O campo sequencia deve estar entre 1 e 9999");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
        }
        #endregion
    }
}
