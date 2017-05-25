using System;
using Consultorio.Common;
using Consultorio.Common.Validations;
using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class Usuario: ModelBase
    {
        #region Properties
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
        public int Ativo { get; set; }
        public bool AtivoCheck { get { return Ativo == 1; } set { Ativo = value ? 1 : 0; } }

        public virtual ICollection<Perfil> Perfis { get; set; }
        #endregion

        public Usuario()
        {
            DataUltimoAcesso = null;
            ModifiedDate = DateTime.Now;
            AddedDate = DateTime.Now;
        }

        #region Methods
        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, ConsultorioMessages.SenhaInvalida);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, ConsultorioMessages.SenhaConfirmacaoInvalida);
            AssertionConcern.AssertArgumentLength(password, 6, 20, ConsultorioMessages.SenhaTamanhoInvalida);
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, ConsultorioMessages.SenhaIguaisInvalido);

            this.Password = PasswordAssertionConcern.EncryptText(password);
        }

        public string ResetPassword()
        {
            Random rnd = new Random();
            string password = rnd.Next(100000, 999999).ToString();
            this.Password = PasswordAssertionConcern.EncryptText(password);

            return Password;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Codigo, "Código do usuário é obrigatório");
            AssertionConcern.AssertArgumentLength(this.Codigo, 10, "Código do usuário deve conter até 10 caracteres");
            AssertionConcern.AssertArgumentNotNull(this.Nome, ConsultorioMessages.NomeUsuarioObrigatorio);
            AssertionConcern.AssertArgumentLength(this.Nome, 200, ConsultorioMessages.NomeUsuarioTamanho);
            EmailAssertionConcern.AssertIsValid(this.Email, "Email é inválido");
        }
        #endregion
    }
}