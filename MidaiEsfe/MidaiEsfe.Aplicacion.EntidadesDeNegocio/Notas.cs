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
        public string NombreExamen { get; set; }
        public string FechaCreacion { get; set; }
        public string NombreModulo { get; set; }
        public string NombrePersonaCalifadora { get; set; }
        public string TipoPersonaCalificadora { get; set; }
        public string FechaHechaExamen { get; set; }
        public string PersonaCalificada { get; set; }
        public string TipoPersonaCalificada { get; set; }

    }
}
