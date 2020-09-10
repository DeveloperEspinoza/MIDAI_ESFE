using System;
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
            string consulta = "INSERT INTO ASIGNACION_DE_MODULO (Id_Persona, Id_Modulo, Fecha_Registro) values(@Id_Persona, @Id_Modulo, @Fecha_Registro)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Persona", pAsignacionDeModulo.IdPersona);
            comando.Parameters.AddWithValue("@Id_Modulo", pAsignacionDeModulo.IdModulo);
            comando.Parameters.AddWithValue("@Fecha_Registro", pAsignacionDeModulo.FechaRegistro);

            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(Asignacion_De_Modulo pAsignacionDeModulo)
        {
            string consulta = "UPDATE ASIGNACION_DE_MODULO SET ID_PERSONA=@Id_Persona, ID_MODULO=@Id_Modulo, FECHA_REGISTRO=@Fecha_Registro WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Persona", pAsignacionDeModulo.IdPersona);
            comando.Parameters.AddWithValue("@Id_Modulo", pAsignacionDeModulo.IdModulo);
            comando.Parameters.AddWithValue("@Fecha_Registro", pAsignacionDeModulo.FechaRegistro);
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
            String consulta = "SELECT TOP 500 a.Id, a.Id_Persona, a.Id_Modulo, a.Fecha_Registro, m.Nombre, p.nombres, p.apellidos FROM ASIGNACION_DE_MODULO a join modulo m on m.Id=a.Id_Modulo join persona p on p.Id=a.Id_Persona";
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
                AsignacionDeModulo.NombreModulo = reader.GetString(4);
                AsignacionDeModulo.NombrePersona = reader.GetString(5);
                AsignacionDeModulo.ApellidoPersona = reader.GetString(6);



                listaAsignacionDeModulo.Add(AsignacionDeModulo);
            }
            return listaAsignacionDeModulo;
        }
        public static Asignacion_De_Modulo BuscarPorId(byte pId)
        {
            string consulta = "SELECT a.Id, a.Id_Persona, a.Id_Modulo, a.Fecha_Registro FROM ASIGNACION_DE_MODULO a WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Asignacion_De_Modulo AsignacionDeModulo = new Asignacion_De_Modulo();
            while (reader.Read())
            {
                AsignacionDeModulo.Id = reader.GetInt64(0);
                AsignacionDeModulo.IdPersona = reader.GetInt64(1);
                AsignacionDeModulo.IdModulo = reader.GetInt64(2);
                AsignacionDeModulo.FechaRegistro = reader.GetDateTime(3);
            }
            return AsignacionDeModulo;
        }

        public static List<Asignacion_De_Modulo> ObtenerTodosLosAlumnosPorModulo(Int64 pIdModulo)
        {

            String consulta = @"
            select 
	            a.ID, 
	            a.ID_PERSONA, 
	            a.ID_MODULO, 
	            a.FECHA_REGISTRO, 
	            p.NOMBRES+' '+p.APELLIDOS as 'Alumno'
            from 
	            ASIGNACION_DE_MODULO a join PERSONA p on p.ID=a.ID_PERSONA
            where 
	            ID_MODULO=@ID_MODULO;
            ";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@ID_MODULO", pIdModulo);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Asignacion_De_Modulo> listaAsignacionDeModulo = new List<Asignacion_De_Modulo>();
            while (reader.Read())
            {
                Asignacion_De_Modulo AsignacionDeModulo = new Asignacion_De_Modulo();
                AsignacionDeModulo.Id = reader.GetInt64(0);
                AsignacionDeModulo.IdPersona = reader.GetInt64(1);
                AsignacionDeModulo.IdModulo = reader.GetInt64(2);
                AsignacionDeModulo.FechaRegistro = reader.GetDateTime(3);
                AsignacionDeModulo.NombrePersona = reader.GetString(4);



                listaAsignacionDeModulo.Add(AsignacionDeModulo);
            }
            return listaAsignacionDeModulo;
        }
    }
}
