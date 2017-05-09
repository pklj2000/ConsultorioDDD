using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class TipoPergunta
    {
        public Dictionary<int, string> TiposPergunta { get; set; }

        public TipoPergunta()
        {
            TiposPergunta = new Dictionary<int, string>()
            {
                { 1, "Texto Livre"},
                { 2, "Numérico"},
                { 3, "Lista"}
            };
        }
    }
}
