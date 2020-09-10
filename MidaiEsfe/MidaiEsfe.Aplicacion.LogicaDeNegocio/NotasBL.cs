using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidaiEsfe.Aplicacion.AccesoADatos;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.LogicaDeNegocio
{
     public class NotasBL
    {
        public int Guardar(Notas pNotas)
        {
            return NotasDAL.Guardar(pNotas);
        }
        public int Modificar(Notas pNotas)
        {
            return NotasDAL.Modificar(pNotas);
        }
        public int Eliminar(Notas pNotas)
        {
            return NotasDAL.Eliminar(pNotas);
        }
        public List<Notas> ObtenerTodos()
        {
            return NotasDAL.ObtenerTodos();
        }
        public Notas BuscarPorId(byte pId)
        {
            return NotasDAL.BuscarPorId(pId);
        }

        public List<Notas> ObtenerTodosPorIdEvaluacion(Int64 IdEvalaucion)
        {
            return NotasDAL.ObtenerTodosPorIdEvaluacion(IdEvalaucion);
        }
    }
}
