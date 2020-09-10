using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidaiEsfe.Aplicacion.AccesoADatos;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.LogicaDeNegocio
{
    public class AsignacionDeModuloBL
    {
        public int Guardar(Asignacion_De_Modulo pAsignacionDeModulo)
        {
            return AsignacionDeModuloDAL.Guardar(pAsignacionDeModulo);
        }
        public int Modificar(Asignacion_De_Modulo pAsignacionDeModulo)
        {
            return AsignacionDeModuloDAL.Modificar(pAsignacionDeModulo);
        }
        public int Eliminar(Asignacion_De_Modulo pAsignacionDeModulo)
        {
            return AsignacionDeModuloDAL.Eliminar(pAsignacionDeModulo);
        }
        public List<Asignacion_De_Modulo> ObtenerTodos()
        {
            return AsignacionDeModuloDAL.ObtenerTodos();
        }
        public Asignacion_De_Modulo BuscarPorId(byte pId)
        {
            return AsignacionDeModuloDAL.BuscarPorId(pId);
        }
        public List<Asignacion_De_Modulo> ObtenerTodosLosAlumnosPorModulo(Int64 idModulo)
        {
            return AsignacionDeModuloDAL.ObtenerTodosLosAlumnosPorModulo(idModulo);
        }
    }
}
