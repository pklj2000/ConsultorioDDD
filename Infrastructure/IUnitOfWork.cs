using Consultorio.Data.Infrastructure;
using System;

namespace Consultorio.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IEmpresaRepository Empresas { get; }
        IDepartamentoRepository Departamentos { get; }
        IEstadoCivilRepository EstadoCivis { get; }
        ITipoExameRepository TipoExames { get; }
        IUsuarioRepository Usuarios { get; }
        int Complete();
    }
}
