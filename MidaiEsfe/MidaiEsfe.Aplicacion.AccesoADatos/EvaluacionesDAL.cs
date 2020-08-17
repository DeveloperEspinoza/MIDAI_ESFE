using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.AccesoADatos
{
    public class EvaluacionesDAL
    {
        public static int Guardar(Evaluaciones pEvaluaciones)
        {
            string consulta = "INSERT INTO Evaluaciones (Id_Modulo, Fecha_Registro, Detalle) values(@Id_Modulo, @Fecha_Registro, @Detalle)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Modulo", pEvaluaciones.IdModulo);
            comando.Parameters.AddWithValue("@Fecha_Registro", pEvaluaciones.FechaRegistro);
            comando.Parameters.AddWithValue("@Detalle", pEvaluaciones.Detalle);

            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(Evaluaciones pEvaluaciones)
        {
            string consulta = "UPDATE Evaluaciones SET Id_Modulo=@Id_Modulo, Fecha_Registro=@Fecha_Registro, Detalle=@Detalle WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Modulo", pEvaluaciones.IdModulo);
            comando.Parameters.AddWithValue("@Fecha_Registro", pEvaluaciones.FechaRegistro);
            comando.Parameters.AddWithValue("@Detalle", pEvaluaciones.Detalle);
            comando.Parameters.AddWithValue("@Id", pEvaluaciones.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar(Evaluaciones pEvaluaciones)
        {
            string consulta = "DELETE FROM Evaluaciones WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEvaluaciones.Id);

            return ComunDB.EjecutarComando(comando);
        }
        public static List<Evaluaciones> ObtenerTodos()
        {
            String consulta = "SELECT TOP 500 e.Id, e.Id_Modulo, e.Fecha_Registro, e.Detalle FROM Evaluaciones e";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Evaluaciones> listaEvaluaciones = new List<Evaluaciones>();
            while (reader.Read())
            {
                Evaluaciones Evaluaciones = new Evaluaciones();
                Evaluaciones.Id = reader.GetInt64(0);
                Evaluaciones.IdModulo = reader.GetInt64(1);
                Evaluaciones.FechaRegistro = reader.GetDateTime(2);
                Evaluaciones.Detalle = reader.GetString(3);
                listaEvaluaciones.Add(Evaluaciones);
            }
            return listaEvaluaciones;
        }
        public static Evaluaciones BuscarPorId(byte pId)
        {
            string consulta = "SELECT e.Id, e.Id_Modulo, e.Fecha_Registro, e.Detalle FROM Evaluaciones a WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Evaluaciones Evaluaciones = new Evaluaciones();
            while (reader.Read())
            {
                Evaluaciones.Id = reader.GetInt64(0);
                Evaluaciones.IdModulo = reader.GetInt64(1);
                Evaluaciones.FechaRegistro = reader.GetDateTime(2);
                Evaluaciones.Detalle = reader.GetString(3);
            }
            return Evaluaciones;
        }
    }
}

