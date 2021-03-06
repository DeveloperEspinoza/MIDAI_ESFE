﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidaiEsfe.Aplicacion.AccesoADatos;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.LogicaDeNegocio
{
    public class EvaluacionesBL
    {
        public int Guardar(Evaluaciones pEvaluaciones)
        {
            return EvaluacionesDAL.Guardar(pEvaluaciones);
        }
        public int Modificar(Evaluaciones pEvaluaciones)
        {
            return EvaluacionesDAL.Modificar(pEvaluaciones);
        }
        public int Eliminar(Evaluaciones pEvaluaciones)
        {
            return EvaluacionesDAL.Eliminar(pEvaluaciones);
        }
        public List<Evaluaciones> ObtenerTodos()
        {
            return EvaluacionesDAL.ObtenerTodos();
        }
        public Evaluaciones BuscarPorId(byte pId)
        {
            return EvaluacionesDAL.BuscarPorId(pId);
        }
        }
}
