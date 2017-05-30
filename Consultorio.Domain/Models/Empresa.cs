using System;
using Consultorio.Common;
using Consultorio.Common.Validations;

namespace Consultorio.Domain.Models
{ 
    public class Empresa: ModelBase
    {
        #region Ctor
        public Empresa(string nome)
        {
            this.Nome = nome;
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        public Empresa()
        {
            this.AddedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
            this.Ativo = 1;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public int Ativo { get; set; }
        public string Observacao { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }
        #endregion

        #region methods
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, ConsultorioMessages.NomeEmpresaObrigatorio);
            AssertionConcern.AssertArgumentLength(this.Nome, 200, ConsultorioMessages.NomeEmpresaInvalido);
            AssertionConcern.AssertArgumentRange(this.Ativo, 0, 1, ConsultorioMessages.AtivoInvalido);
        }

        public override string ToString()
        {
            return this.Nome;
        }
        #endregion
    }
}
