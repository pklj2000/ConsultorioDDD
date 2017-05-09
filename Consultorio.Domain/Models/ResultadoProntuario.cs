using System.Collections.Generic;

namespace Consultorio.Domain.Models
{
    public class ResultadoProntuario:ModelBase
    {
        public Dictionary<int, string> ResultadosProntuario { get; set; }

        public ResultadoProntuario()
        {
            ResultadosProntuario = new Dictionary<int, string>()
            {
                {1, "Apto" },
                {2, "Apto com restrições" },
                {3, "Inapto" }
            };
        }
    }
}
