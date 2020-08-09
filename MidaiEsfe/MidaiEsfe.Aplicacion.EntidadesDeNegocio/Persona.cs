using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidaiEsfe.Aplicacion.EntidadesDeNegocio
{
    public class Persona
    {
        public Int64 Id { get; set; }

        public Int64 IdTipoPersona { get; set; }

        public String Nombres { get; set; }

        public String Apellidos { get; set; }
        public String NombreTipoPersona { get; set; }


    }
}
