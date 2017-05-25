using System;
using Consultorio.Common;
using Consultorio.Common.Validations;
using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class TipoExame: ModelBase
    {
        #region Properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get; set; }

        public virtual ICollection<Exame> Exame { get; set; }
        #endregion  

        #region ctor
        public TipoExame()
        {
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Tipo do Exame é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo Tipo do Exame deve conter até 200 caracteres");
            AssertionConcern.AssertArgumentNotNull(this.AddedDate, "Data de inclusão não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.ModifiedDate, "Data da última modificação não preenchida");
            AssertionConcern.AssertArgumentNotNull(this.UsuarioId, "Usuário responsável não preenchido");
        }
        #endregion

    }
}
