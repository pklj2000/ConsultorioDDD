using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class ExameRepository : Repository<Exame>, IExameRepository
    {
        public ExameRepository(ConsultorioContext context) : base(context)
        {
        }

        public override Exame GetById(int id)
        {
            return Context.Exames.Include("TipoExame").Include("Periodicidade").Where(x => x.Id == id).FirstOrDefault();
        }

        public override void Update(Exame entity)
        {
            Exame _exame;
            _exame = Context.Exames.Include("TipoExame").FirstOrDefault(x => x.Id == entity.Id);

            foreach (var item in _exame.TipoExame.ToList())
            {
                _exame.TipoExame.Remove(item);
            }

            foreach (var item in entity.TipoExame)
            {
                _exame.TipoExame.Add(item);
            }

            Context.Entry(_exame).CurrentValues.SetValues(entity);
        }
    }
}
