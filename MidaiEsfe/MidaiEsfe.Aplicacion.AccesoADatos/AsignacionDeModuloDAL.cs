﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.AccesoADatos
{
    public class AsignacionDeModuloDAL
    {
        public static int Guardar(Asignacion_De_Modulo pAsignacionDeModulo)
        {
            string consulta = "INSERT INTO ASIGNACION_DE_MODULO (Id_Persona,Id_Modulo, Fecha_Registro) values(@IdPersona, @IdModulo, @FechaRegistro)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdPersona", pAsignacionDeModulo.IdPersona);
            comando.Parameters.AddWithValue("@IdModulo", pAsignacionDeModulo.IdModulo);
            comando.Parameters.AddWithValue("@FechaRegistro", pAsignacionDeModulo.FechaRegistro);

            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(Asignacion_De_Modulo pAsignacionDeModulo)
        {
            string consulta = "UPDATE ASIGNACION_DE_MODULO SET IdPersona=@IdPersona, IdModulo=@IdModulo, FechaRegistro=@FechaRegistro WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdPersona", pAsignacionDeModulo.IdPersona);
            comando.Parameters.AddWithValue("@IdModulo", pAsignacionDeModulo.IdModulo);
            comando.Parameters.AddWithValue("@FechaRegistro", pAsignacionDeModulo.FechaRegistro);
            comando.Parameters.AddWithValue("@Id", pAsignacionDeModulo.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar(Asignacion_De_Modulo pAsignacionDeModulo)
        {
            string consulta = "DELETE FROM ASIGNACION_DE_MODULO WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pAsignacionDeModulo.Id);

            return ComunDB.EjecutarComando(comando);
        }
        public static List<Asignacion_De_Modulo> ObtenerTodos()
        {
            String consulta = "SELECT TOP 500 a.Id, a.Id_Persona, a.Id_Modulo, a.Fecha_Registro FROM ASIGNACION_DE_MODULO a";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Asignacion_De_Modulo> listaAsignacionDeModulo = new List<Asignacion_De_Modulo>();
            while (reader.Read())
            {
                Asignacion_De_Modulo AsignacionDeModulo = new Asignacion_De_Modulo();
                AsignacionDeModulo.Id = reader.GetInt64(0);
                AsignacionDeModulo.IdPersona = reader.GetInt64(1);
                AsignacionDeModulo.IdModulo = reader.GetInt64(2);
                AsignacionDeModulo.FechaRegistro = reader.GetDateTime(3);
                listaAsignacionDeModulo.Add(AsignacionDeModulo);
            }
            return listaAsignacionDeModulo;
        }
        public static Asignacion_De_Modulo BuscarPorId(byte pId)
        {
            string consulta = "SELECT a.Id, a.IdPersona, a.IdModulo, a.FechaRegistro FROM ASIGNACION_DE_MODULO a WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Asignacion_De_Modulo AsignacionDeModulo = new Asignacion_De_Modulo();
            while (reader.Read())
            {
                AsignacionDeModulo.Id = reader.GetByte(0);
                AsignacionDeModulo.IdPersona = reader.GetByte(1);
                AsignacionDeModulo.IdModulo = reader.GetByte(2);
                AsignacionDeModulo.FechaRegistro = reader.GetDateTime(3);
            }
            return AsignacionDeModulo;
        }
    }
}
