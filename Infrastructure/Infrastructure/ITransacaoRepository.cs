using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Data.Infrastructure
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        List<string> GetTransacaoJanelaUsuario(string usuarioCodigo);
    }
}
