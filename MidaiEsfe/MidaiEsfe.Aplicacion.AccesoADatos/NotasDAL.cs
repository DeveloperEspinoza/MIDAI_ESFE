using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.AccesoADatos
{
    public class NotasDAL
    {
        public static int Guardar(Notas pNotas)
        {
            string consulta = "INSERT INTO NOTAS (Id_Evaluaciones, Id_Asignacion_De_Modulo, Nota) values(@Id_Evaluaciones, @Id_Asignacion_De_Modulo, @Nota)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Evaluaciones", pNotas.IdEvaluacion);
            comando.Parameters.AddWithValue("@Id_Asignacion_De_Modulo", pNotas.IdAsignacionDeModulo);
            comando.Parameters.AddWithValue("@Nota", pNotas.Nota);

            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(Notas pNotas)
        {
            string consulta = "UPDATE Notas SET Id_Evaluaciones=@Id_Evaluaciones, Id_Asignacion_De_Modulo=@Id_Asignacion_De_Modulo, Nota=@Nota WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Evaluaciones", pNotas.IdEvaluacion);
            comando.Parameters.AddWithValue("@Id_Asignacion_De_Modulo", pNotas.IdAsignacionDeModulo);
            comando.Parameters.AddWithValue("@Nota", pNotas.Nota);
            comando.Parameters.AddWithValue("@Id", pNotas.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar(Notas pNotas)
        {
            string consulta = "DELETE FROM Notas WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pNotas.Id);

            return ComunDB.EjecutarComando(comando);
        }
        public static List<Notas> ObtenerTodos()
        {
            String consulta = @"
                SELECT
                        TOP 500
                        n.Id, 
	                    n.Id_Evaluaciones, 
	                    n.Id_Asignacion_De_Modulo, 
	                    n.Nota,
	                    e.DETALLE AS 'NOMBRE_EXAMEN',
	                    e.FECHA_REGISTRO,
	                    m.NOMBRE as 'MODULO',
	                    p.NOMBRES + p.APELLIDOS as 'PERSONA_CALIFICADORA' ,
	                    t.NOMBRE as 'TIPO_PERSONA',
	                    a.FECHA_REGISTRO as 'FECHA_QUE_HIZO_EXAMEN',
	                    pe.NOMBRES + pe.APELLIDOS as 'PERSONA_CALIFICADA',
	                    ti.NOMBRE as 'TIPO_PERSONA_QUE_HIZO_EXAMEN'
                    FROM
                        Notas n
                        -- para sacar la informacion de la persona que aplicara el examen
                        join evaluaciones e on e.ID = n.ID_EVALUACIONES
                        join MODULO  m on m.ID = e.ID_MODULO
                        join PERSONA p on p.ID = m.ID_PERSONA
                        JOIN TIPO_PERSONA t on t.ID = p.ID_TIPO_PERSONA
                        -- para sacar los datos de la persona que ya hizo el examnen
                        JOIN ASIGNACION_DE_MODULO a on a.ID = n.ID_ASIGNACION_DE_MODULO
                        JOIN PERSONA pe on pe.ID = a.ID_PERSONA
                        JOIN TIPO_PERSONA ti on ti.ID = pe.ID_TIPO_PERSONA
                ";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Notas> listaNotas = new List<Notas>();
            while (reader.Read())
            {
                Notas Notas = new Notas();
                Notas.Id = reader.GetInt64(0);
                Notas.IdEvaluacion = reader.GetInt64(1);
                Notas.IdAsignacionDeModulo = reader.GetInt64(2);
                Notas.Nota = reader.GetInt32(3);
                Notas.NombreExamen = reader.GetString(4);
                Notas.FechaCreacion = Convert.ToString(reader.GetDateTime(5));
                Notas.NombreModulo = reader.GetString(6);
                Notas.NombrePersonaCalifadora = reader.GetString(7);
                Notas.TipoPersonaCalificadora = reader.GetString(8);
                Notas.FechaHechaExamen = Convert.ToString(reader.GetDateTime(9));
                Notas.PersonaCalificada = reader.GetString(10);
                Notas.TipoPersonaCalificada = reader.GetString(11);
                listaNotas.Add(Notas);
            }
            return listaNotas;
        }
        public static Notas BuscarPorId(byte pId)
        {
            string consulta = "SELECT n.Id, e.Id_Evaluaciones, n.Id_Asignacion_De_Modulo, n.Nota FROM Notas n WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Notas Notas = new Notas();
            while (reader.Read())
            {
                Notas.Id = reader.GetByte(0);
                Notas.IdEvaluacion = reader.GetByte(1);
                Notas.IdAsignacionDeModulo = reader.GetByte(2);
                Notas.Nota = reader.GetByte(3);
            }
            return Notas;
        }

        public static List<Notas> ObtenerTodosPorIdEvaluacion(Int64 IdEvalaucion)
        {
            String consulta = @"
               SELECT 
	                N.ID,
	                N.ID_EVALUACIONES,
	                N.ID_ASIGNACION_DE_MODULO,
	                N.NOTA,
	                E.FECHA_REGISTRO,
	                E.DETALLE AS EXAMEN,
	                M.NOMBRE AS MODULO,
	                PD.NOMBRES+' ' +PD.APELLIDOS AS DOCENTE,
	                PE.NOMBRES+' ' +PE.APELLIDOS AS ALUMNO

                FROM
	                NOTAS N JOIN EVALUACIONES E ON E.ID=N.ID_EVALUACIONES JOIN
	                MODULO M ON M.ID=E.ID_MODULO JOIN
	                PERSONA PD ON PD.ID=M.ID_PERSONA JOIN
	                ASIGNACION_DE_MODULO A ON A.ID=N.ID_ASIGNACION_DE_MODULO JOIN
	                PERSONA PE ON PE.ID=A.ID_PERSONA
                WHERE 
	                N.ID_EVALUACIONES=@ID_EVALUACIONES
                ";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@ID_EVALUACIONES", IdEvalaucion);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Notas> listaNotas = new List<Notas>();
            while (reader.Read())
            {
                Notas Notas = new Notas();
                Notas.Id = reader.GetInt64(0);
                Notas.IdEvaluacion = reader.GetInt64(1);
                Notas.IdAsignacionDeModulo = reader.GetInt64(2);
                Notas.Nota = reader.GetInt32(3);
                Notas.FechaHechaExamen = Convert.ToString(reader.GetDateTime(4));
                Notas.NombreExamen = reader.GetString(5);
                Notas.NombreModulo = reader.GetString(6);
                Notas.NombrePersonaCalifadora = reader.GetString(7);
                Notas.PersonaCalificada = reader.GetString(8);
                listaNotas.Add(Notas);
            }
            return listaNotas;
        }
    }
}
