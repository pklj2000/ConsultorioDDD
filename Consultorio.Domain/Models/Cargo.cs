using Consultorio.Common;
using Consultorio.Common.Validations;
using System;
using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Cargo: ModelBase
    {
        #region properties
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int DepartamentoId { get; set; }
        public int EmpresaId { get; set; }
        public int PeriodicidadeId { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }

        public virtual Periodicidade Periodicidade { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Exame> Exames { get; set; }
        public virtual HashSet<int> ExamesKeys { get; set; }

        public virtual ICollection<Risco> Riscos { get; set; }
        public virtual HashSet<int> RiscosKeys { get; set; }
        #endregion

        #region ctor
        public Cargo()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Ativo = 1;

            Exames = new List<Exame>();
        }
        #endregion  

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Descricao, "O campo Departamento é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Descricao, 200, "O campo Departamento deve ter até 200 caracteres");
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
            AssertionConcern.AssertArgumentNotNull(this.DepartamentoId, "O campo Departamento é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.EmpresaId, "O campo Empresa é obrigatório");
            AssertionConcern.AssertArgumentNotNull(this.PeriodicidadeId, "O campo Periodicidade é obrigatório");
        }
        #endregion
    }
}
