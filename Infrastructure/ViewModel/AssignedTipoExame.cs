using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data.ViewModel
{
    public class AssignedTipoExame
    {
        public Int32 Id { get; set; }
        public string Descricao { get; set; }
        public bool Assigned { get; set; }
    }
}
