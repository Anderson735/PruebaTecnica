using System;
using System.Data.SqlClient;

namespace Datos
{
    public class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = null;
            try
            {
                string connectionString = "Data Source=(local);Initial Catalog=pruebaTecnica;Integrated Security=True;User Id=.;";
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión a la base de datos: " + ex.Message);
            }
            return conn;
        }
    }
}
