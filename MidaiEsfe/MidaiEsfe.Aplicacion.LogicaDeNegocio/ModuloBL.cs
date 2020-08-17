using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidaiEsfe.Aplicacion.AccesoADatos;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.LogicaDeNegocio
{
    public class ModuloBL
    {
        public int  Guardar(Modulo pModulo)
        {
            return ModuloDAL.Guardar(pModulo);
        }
        public int Modificar(Modulo pModulo)
        {
            return ModuloDAL.Modificar(pModulo);
        }
        public int Eliminar(Modulo pModulo)
        {
            return ModuloDAL.Eliminar(pModulo);
        }
        public List<Modulo> ObtenerTodos()
        {
            return ModuloDAL.ObtenerTodos();
        }
        public Modulo BuscarPorId(byte pId)
        {
            return ModuloDAL.BuscarPorId(pId);
        }
    }
}
