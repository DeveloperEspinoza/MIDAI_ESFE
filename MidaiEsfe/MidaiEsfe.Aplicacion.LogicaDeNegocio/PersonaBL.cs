﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidaiEsfe.Aplicacion.AccesoADatos;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.LogicaDeNegocio
{
    public class PersonaBL
    {
        public int Guardar(Persona pPersona)
        {
            return PersonaDAL.Guardar(pPersona);
        }
        public  int Modificar(Persona pPersona)
        {
            return PersonaDAL.Modificar(pPersona);
        }
        public  int Eliminar(Persona pPersona)
        {
            return PersonaDAL.Eliminar(pPersona);
        }
        public  List<Persona> ObtenerTodos()
        {
            return PersonaDAL.ObtenerTodos();
        }
        public  Persona BuscarPorId(byte pId)
        {
            return PersonaDAL.BuscarPorId(pId);
        }
    }
}
