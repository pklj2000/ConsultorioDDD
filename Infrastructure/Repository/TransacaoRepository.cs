using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultorio.Data.Repository
{
    class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(ConsultorioContext context):base(context)
        {
        }
        
        
        public List<string> GetTransacaoJanelaUsuario(string usuarioCodigo)
        {
            StringBuilder _sql = new StringBuilder("SELECT DISTINCT Transacao.Janela ");
            _sql.AppendFormat(" FROM Usuario, UsuarioPerfil, PerfilTransacao, Transacao ");
            _sql.AppendFormat(" WHERE Usuario.Id = UsuarioPerfil.UsuarioId ");
            _sql.AppendFormat(" AND UsuarioPerfil.PerfilId = PerfilTransacao.PerfilId ");
            _sql.AppendFormat(" AND PerfilTransacao.TransacaoId = Transacao.Id ");
            _sql.AppendFormat(" AND Usuario.Codigo = '{0}'", usuarioCodigo);

            var trx = Context.Database.SqlQuery<string>(_sql.ToString()).ToList();

            return trx;
        }
        
    }
}
