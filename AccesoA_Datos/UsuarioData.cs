using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace Acceso_aDatos
{
    public static class UsuarioData
    {
        //Obtener usuario
        public static List<Usuario> ObtenerUsuario(int IdUsuario)
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail " +
                        "FROM Usuario WHERE Id=@Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdUsuario;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();
                                usuario.IdUsuario = Convert.ToInt32(dr["Id"]);
                                usuario.Nombre = dr["Nombre"].ToString();
                                usuario.Apellido = dr["Apellido"].ToString();
                                usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                usuario.Contrasenia = dr["Contraseña"].ToString();
                                usuario.Email = dr["Mail"].ToString();
                                lista.Add(usuario);
                            }
                            throw new Exception("Id no enocontrado");
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }

        //Listar usuarios
        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();
                                usuario.IdUsuario = Convert.ToInt32(dr["Id"]);
                                usuario.Nombre = dr["Nombre"].ToString();
                                usuario.Apellido = dr["Apellido"].ToString();
                                usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                usuario.Contrasenia = dr["Contraseña"].ToString();
                                usuario.Email = dr["Mail"].ToString();
                                lista.Add(usuario);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }
 
        //Crear usuario
        public static void CrearUsuario(Usuario usuario)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                        "VALUES (@Nombre, @Apellido, @NombreUsuario, @Contrasenia, @Mail);";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Contrasenia", SqlDbType.VarChar) { Value = usuario.Contrasenia });
                    comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Email });
                }
                conexion.Close();
            }
        }
        //Modificar usuario
        public static void ModificarUsuario(Usuario usuario)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "UPDATE Usuario SET" +
                        "Nombre = @Nombre, " +
                        "Apellido = @Apellido , " +
                        "NombreUsuario = @NombreUsuario," +
                        "Contarseña = @Contrasenia " +
                        "Mail = @Mail " +
                        "WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = usuario.IdUsuario });
                    comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Contrasenia", SqlDbType.VarChar) { Value = usuario.Contrasenia });
                    comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Email });
                }
                throw new Exception("Id no enocontrado");
                conexion.Close();
            }
        }
        //Eliminar usuario
        public static void EliminarUsuario(Usuario usuario)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "DELETE FROM Usuario WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = usuario.IdUsuario });
                }
                conexion.Close();
            }
        }
    }
}
