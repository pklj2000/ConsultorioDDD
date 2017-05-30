using Consultorio.Common;
using Consultorio.Common.Validations;
using System;

namespace Consultorio.Domain.Models
{
    public class Departamento: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public int EmpresaId { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } }

        public virtual Empresa Empresa { get; set; }
        #endregion

        #region ctor
        public Departamento()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Ativo = 1;
        }
        #endregion  

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "");
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo Departamento é obrigatório");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
        }

        public override string ToString()
        {
            return this.Descricao;
        }
        #endregion
    }
}
