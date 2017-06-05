using Consultorio.Common;
using Consultorio.Common.Validations;
using System;
using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Pergunta: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Sequencia { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }
        public int PerguntaGrupoId { get; set; }
        public int TipoRespostaId { get; set; }
        public int RespostaObrigatoria { get; set; }
        public string RespostaItem { get; set; }

        public virtual PerguntaGrupo PerguntaGrupo { get; set; }
        public Dictionary<int, string> TipoResposta { get; set; }
        #endregion

        #region ctor
        public Pergunta()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Ativo = 1;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Pergunta é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo Pergunta deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentRange(this.Sequencia, 1, 9999, "O campo sequencia deve estar entre 1 e 9999");
            AssertionConcern.AssertArgumentRange(this.PerguntaGrupoId, 1, 999999, "O grupo da pergunta está inválido");
            AssertionConcern.AssertArgumentRange(this.TipoRespostaId, 1, 999999, "O tipo da resposta está inválido");
            AssertionConcern.AssertArgumentRange(this.RespostaObrigatoria, 0, 1, "O campo Resposta Obrigatória está inválido");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
        }
        #endregion
    }
}
