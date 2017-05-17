using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Data.Infrastructure;
using Consultorio.Common.Validations;
using Consultorio.Data.Context;
using Consultorio.Data;

namespace Consultorio.Service
{
    public class LoginService : ILoginService
    {
        public bool ValidatePassword(string usuario, string password)
        {
            Usuario _usuario;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _usuario = uow.Usuarios.GetByCodigo(usuario);
            }

            if(_usuario == null)
                throw new Exception(string.Format("Usuário {0} não encontrado", usuario));

            string _password = String.IsNullOrEmpty(password) ? "" : PasswordAssertionConcern.EncryptText(password);
            string _passwordBase = String.IsNullOrEmpty(_usuario.Password) ? "" : _usuario.Password; 
            return _passwordBase == _password;
        }

        public bool HasPermission(string usuario, string transaction)
        {
            if(usuario.ToLower() == "terama" && transaction == "Empresa:Visualizar")
            {
                return true;
            }
            return false;
        }
    }
}
