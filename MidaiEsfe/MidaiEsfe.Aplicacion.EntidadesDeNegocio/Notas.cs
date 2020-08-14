using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidaiEsfe.Aplicacion.EntidadesDeNegocio
{
    public class Notas
    {
        public Int64 Id { get; set; }

        public Int64 IdEvaluacion { get; set; }

        public Int64 IdAsignacionDeModulo { get; set; }

        public Int64 Nota { get; set; }
    }
}
