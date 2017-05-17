using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Data.Repository;

namespace Consultorio.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConsultorioContext _context;

        public UnitOfWork(ConsultorioContext context)
        {
            _context = context;
            Empresas = new EmpresaRepository(_context);
            Departamentos = new DepartamentoRepository(_context);
            Usuarios = new UsuarioRepository(_context);
            EstadoCivis = new EstadoCivilRepository(_context);
            TipoExames = new TipoExameRepository(_context);
            Transacoes = new TransacaoRepository(_context);
        }

        public IEmpresaRepository Empresas { get; private set; }
        public IDepartamentoRepository Departamentos { get; private set; }
        public IEstadoCivilRepository EstadoCivis { get; private set; }
        public ITipoExameRepository TipoExames { get; private set; }
        public IUsuarioRepository Usuarios { get; private set; }
        public ITransacaoRepository Transacoes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
