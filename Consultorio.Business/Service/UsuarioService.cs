using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Data.Infrastructure;
using Consultorio.Common.Validations;

namespace Consultorio.Service
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _repository = new UsuarioRepository();

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _repository.GetAll();
        }

        public Usuario GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Usuario GetByCodigo(string codigo)
        {
            return _repository.GetByCodigo(codigo);
        }

        public void Insert(Usuario usuario)
        {
            _repository.Insert(usuario);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Usuario usuario)
        {
            _repository.Update(usuario);
        }

        public bool ValidatePassword(string usuario, string password)
        {
            Usuario _usuario = _repository.GetByCodigo(usuario);

            if(_usuario == null)
                throw new Exception(string.Format("Usuário {0} não encontrado", usuario));

            string _password = String.IsNullOrEmpty(password) ? "" : PasswordAssertionConcern.EncryptText(password);
            string _passwordBase = String.IsNullOrEmpty(_usuario.Password) ? "" : _usuario.Password; 
            return _passwordBase == _password;
        }
    }
}
