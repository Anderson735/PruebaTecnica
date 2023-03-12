using Datos.DTOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Datos.Procedimientos
{
    public class PUsuario
    {
        public int AgregarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@identificacion", identificacion);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", sexo);
                    resultado = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar usuario: " + ex.Message);
            }
            return resultado;
        }

        public int ModificarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@identificacion", identificacion);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", sexo);
                    resultado = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar usuario: " + ex.Message);
            }
            return resultado;
        }

        public DataTable ConsultarUsuarios()
        {
            DataTable dtUsuarios = new DataTable();
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarUsuarios", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtUsuarios);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar usuarios: " + ex.Message);
            }
            return dtUsuarios;
        }

        public UsuarioDTO ObtenerUsuarioPorId(string identificacion)
        {
            UsuarioDTO usuario = null;
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ObtenerUsuarioPorId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@identificacion", identificacion);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario = new UsuarioDTO();
                        usuario.Identificacion = reader.GetString(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.FechaNacimiento = reader.GetDateTime(2);
                        usuario.Sexo = reader.GetChar(3);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener usuario por id: " + ex.Message);
            }
            return usuario;
        }

        public int EliminarUsuario(string identificacion)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@identificacion", identificacion);
                    resultado = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
            }
            return resultado;
        }
    }
}
