using Consultorio.Common.Validations;
using System;
using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Exame: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int EmiteSolicitacaoExame { get; set; }
        public int EmitePorPeriodicidade { get; set; }
        public int Ativo { get; set; }
        public int PeriodicidadeId { get; set; }

        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }
        public bool EmiteSolicitacaoExameCheck { get { return EmiteSolicitacaoExame == 1; } set { EmiteSolicitacaoExame = value ? 1 : 0; } }
        public bool EmitePorPeriodicidadeCheck { get { return EmitePorPeriodicidade == 1; } set { EmitePorPeriodicidade = value ? 1 : 0; } }

        public virtual Periodicidade Periodicidade { get; set; }
        public virtual ICollection<TipoExame> TipoExame { get; set; }
        public virtual ICollection<Cargo> Cargo { get; set; }
        #endregion  

        #region ctor
        public Exame()
        {
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
            this.Ativo = 1;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Descrição é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo Descrição deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentRange(this.EmiteSolicitacaoExame, 0, 1, "O campo Emitir por Solicitação de Exame está nulo");
            AssertionConcern.AssertArgumentRange(this.EmitePorPeriodicidade, 0, 1, "O campo Emitir por Periodicidade está nulo");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, "O campo Ativo está nulo");
            AssertionConcern.AssertArgumentNotNull(this.AddedDate, "Data de inclusão não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.ModifiedDate, "Data da última modificação não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.UsuarioId, "Usuário responsável não preenchido");
        }
        #endregion
    }
}
