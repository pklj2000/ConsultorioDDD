using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Data.Infrastructure
{
    public interface IPerguntaRepository: IRepository<Pergunta>
    {
        ICollection<Pergunta> GetByGrupo(int grupoId);
    }
}
