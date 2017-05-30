using System;
using System.Collections.Generic;
using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(ConsultorioContext context) : base(context)
        {
        }

        public override Cargo GetById(int id)
        {
            Cargo _cargo = Context.Cargos
                .Include("Departamento")
                .Include("Empresa")
                .Include("Periodicidade")
                .Include("Exames")
                .Include("Riscos")
                .FirstOrDefault(x => x.Id == id);

            _cargo.ExamesKeys = new HashSet<int>(from ex in _cargo.Exames
                                select ex.Id);

            _cargo.RiscosKeys = new HashSet<int>(from ex in _cargo.Riscos
                                                 select ex.Id);
            return _cargo;
        }

        public IEnumerable<Cargo> GetByEmpresa(int id)
        {
            return Context.Cargos.Include("Departamento").Where(x => x.EmpresaId == id).ToList();
        }

        public override void Insert(Cargo entity)
        {
            base.Insert(entity);
        }

        public override void Update(Cargo entity)
        {
            Cargo _cargo;
            _cargo = GetById(entity.Id);

            foreach (var item in _cargo.Exames.ToList())
                _cargo.Exames.Remove(item);

            foreach (var item in entity.Exames)
                _cargo.Exames.Add(item);

            foreach (var item in _cargo.Riscos.ToList())
                _cargo.Riscos.Remove(item);

            foreach (var item in entity.Riscos)
                _cargo.Riscos.Add(item);

            Context.Entry(_cargo).CurrentValues.SetValues(entity);
        }

        public IEnumerable<Cargo> GetByDepartamento(int departamentoId)
        {
            return Context.Cargos.Include("Departamento")
                .Where(x => x.DepartamentoId == departamentoId).ToList();
        }
    }
}
