using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class ResultadoClinico: ModelBase
    {
        public Dictionary<int, string> ResultadosClinicos { get; set; }

        public ResultadoClinico()
        {
            ResultadosClinicos = new Dictionary<int, string>()
            {
                {1, "Normal" },
                {2, "Anormal" }
            };
        }
    }
}
