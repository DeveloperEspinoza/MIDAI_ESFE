using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidaiEsfe.Aplicacion.EntidadesDeNegocio
{
     public  class Asignacion_De_Modulo
    {
        public Int64 Id { get; set; }

        public Int64 IdPersona { get; set; }

        public Int64 IdModulo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string NombrePersona { get; set; }

        public string ApellidoPersona { get; set; }
        public string NombreModulo { get; set; }
    }
}
