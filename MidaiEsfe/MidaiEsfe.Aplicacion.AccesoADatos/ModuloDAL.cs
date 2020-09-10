using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;

namespace MidaiEsfe.Aplicacion.AccesoADatos
{
    public class ModuloDAL
    {
        public static int Guardar(Modulo pModulo)
        {
            string consulta = "INSERT INTO MODULO(ID_PERSONA, Nombre) values(@Id_Persona, @Nombres)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Persona", pModulo.IdPersona);
            comando.Parameters.AddWithValue("@Nombres", pModulo.Nombre);

            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(Modulo pModulo)
        {
            string consulta = "UPDATE Modulo SET ID_PERSONA=@Id_Persona, NOMBRE=@Nombre WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id_Persona", pModulo.IdPersona);
            comando.Parameters.AddWithValue("@Nombre", pModulo.Nombre);
            comando.Parameters.AddWithValue("@Id", pModulo.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar(Modulo pModulo)
        {
            string consulta = "DELETE FROM Modulo WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pModulo.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static List<Modulo> ObtenerTodos()
        {
            String consulta = "SELECT TOP 500 m.Id, m.ID_PERSONA, m.Nombre + ' - ' +p.Nombres + ' ' +p.APELLIDOS as 'Nombre' , p.Nombres as Nombre_Persona FROM Modulo m join Persona p on p.Id= m.ID_PERSONA";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Modulo> listaModulo = new List<Modulo>();
            while (reader.Read())
            {
                Modulo Modulo = new Modulo();
                Modulo.Id = reader.GetInt64(0);
                Modulo.IdPersona = reader.GetInt64(1);
                Modulo.Nombre = reader.GetString(2);
                Modulo.Nombre_Persona = reader.GetString(3);
                listaModulo.Add(Modulo);
            }
            return listaModulo;
        }
        public static Modulo BuscarPorId(byte pId)
        {
            string consulta = "SELECT m.Id, m.Id_Persona, m.Nombre FROM Modulo m WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Modulo Modulo = new Modulo();
            while (reader.Read())
            {
                Modulo.Id = reader.GetInt64(0);
                Modulo.IdPersona = reader.GetInt64(1);
                Modulo.Nombre = reader.GetString(2);
            }
            return Modulo;
        }
    }
}

