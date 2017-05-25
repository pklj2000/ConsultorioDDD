﻿using Consultorio.Data.Infrastructure;
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
        ITransacaoRepository Transacoes { get; }
        IPerfilRepository Perfis { get; }
        IRiscoRepository Riscos { get; }
        IPeriodicidadeRepository Periodicidades { get; }
        IExameRepository Exames { get; }
        int Complete();
    }
}
