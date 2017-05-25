using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class PerfilRepository: Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(ConsultorioContext context) : base(context)
        {
        }

        public override Perfil GetById(int id)
        {
            Perfil _perfil = base.GetById(id);
            _perfil = Context.Perfis.Include("Transacao").Where(x => x.Id == id).FirstOrDefault();
            return _perfil;
        }

        public override void Update(Perfil entity)
        {
            Perfil _perfil;
            _perfil = Context.Perfis.Include("Transacao").FirstOrDefault(x=>x.Id == entity.Id);
           
            foreach(var item in _perfil.Transacao.ToList())
            {
                _perfil.Transacao.Remove(item);
            }

            foreach(var item in entity.Transacao)
            {
                _perfil.Transacao.Add(item);
            }
            
            Context.Entry(_perfil).CurrentValues.SetValues(entity);
        }

    }
}
