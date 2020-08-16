using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidaiEsfe.Aplicacion.AccesoADatos;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.LogicaDeNegocio
{
    public class TipoPersonaBL
    {
        public int Guardar (TipoPersona pTipoPersona)
        {
            return TipoPersonaDAL.Guardar(pTipoPersona);
        }

        public  int Modificar(TipoPersona pTipoPersona)
        {
            return TipoPersonaDAL.Modificar(pTipoPersona);
        }
        public  int Eliminar (TipoPersona pTipoPersona)
        {
            return TipoPersonaDAL.Eliminar(pTipoPersona);
        }
        public List<TipoPersona> ObtenerTodos()
        {
            return TipoPersonaDAL.ObtenerTodos();
        }
        public  TipoPersona BuscarPorId(byte pId)
        {
            return TipoPersonaDAL.BuscarPorId(pId);
        }
    }

}
