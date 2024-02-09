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
    public static class VentaData
    {
        //Obener venta
        public static List<Venta> ObtenerVenta(int IdVenta)
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario " +
                        "FROM Venta WHERE Id=@Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdVenta;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var venta = new Venta();
                                venta.IdVenta = Convert.ToInt32(dr["Id"]);
                                venta.Comentarios = dr["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(venta);
                            }
                            throw new Exception("Id no enocontrado");
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }

        //Listar ventas
        public static List<Venta> ListarVenta()
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta;";

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
                                var venta = new Venta();
                                venta.IdVenta = Convert.ToInt32(dr["Id"]);
                                venta.Comentarios = dr["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(venta);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }

        //Crear venta
        public static void CrearVenta(Venta venta)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "INSERT INTO Venta (Comentarios, IdUsuario)" +
                        "VALUES (@Comentarios, @IdUsuario);";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = venta.IdUsuario });
                }
                conexion.Close();
            }
        }
        //Modificar venta
        public static void ModificarVenta(Venta venta)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "UPDATE Venta SET" +
                        "Comentarios = @Comentarios, " +
                        "IdUsuario = @IdUsuario " +
                        "WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = venta.IdVenta });
                    comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = venta.IdUsuario });
                }
                throw new Exception("Id no enocontrado");
                conexion.Close();
            }
        }
        //Eliminar venta
        public static void EliminarVenta(Venta venta)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "DELETE FROM Venta WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = venta.IdVenta });
                }
                conexion.Close();
            }
        }
    }
}
