using System;
using Consultorio.Domain.Models;

namespace Consultorio.Domain
{
    public abstract class ModelBase
    {
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UsuarioId { get; set; }

    }
}
