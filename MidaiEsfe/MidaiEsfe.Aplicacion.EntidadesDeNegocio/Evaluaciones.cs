using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidaiEsfe.Aplicacion.EntidadesDeNegocio
{
    public class Evaluaciones
    {
        public Int64 Id { get; set; }

        public Int64 IdModulo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public String Detalle { get; set; }

        public String Nombre_Modulo { get; set; }
    }
}
