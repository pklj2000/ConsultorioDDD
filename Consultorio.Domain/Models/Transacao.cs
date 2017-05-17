using Consultorio.Common.Validations;
using System;

namespace Consultorio.Domain.Models
{
    public class Transacao : ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Janela { get; set; }
        public string Objeto { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0 ; } }
        #endregion

        #region ctor
        public Transacao()
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
            AssertionConcern.AssertArgumentNotNull(this.Janela, "O campo Janela é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Janela, 200, "O campo Janela deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentLength(this.Objeto, 200, "O campo Objeto deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentNotNull(this.AddedDate, "Data de inclusão não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.ModifiedDate, "Data da última modificação não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.UsuarioId, "Usuário responsável não preenchido");
        }
        #endregion
    }
}