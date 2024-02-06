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
    public static class ProductoVendidoData
    {
        //Obtener producto vendido
        public static List<ProductoVendido> ObtenerProductoVendido(int IdProductoVendido)
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta " +
                        "FROM ProductoVendido WHERE Id=@Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdProductoVendido;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var productovendido = new ProductoVendido();
                                productovendido.IdProductoVendido = Convert.ToInt32(dr["Id"]);
                                productovendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productovendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productovendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                                lista.Add(productovendido);
                            }
                            throw new Exception("Id no enocontrado");
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }

        //Listar productos vendidos
        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido;";

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
                                var productovendido = new ProductoVendido();
                                productovendido.IdProductoVendido = Convert.ToInt32(dr["Id"]);
                                productovendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productovendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productovendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                                lista.Add(productovendido);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }

        //Crear producto vendido
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta)" +
                        "VALUES (@Stock, @IdProducto, @IdVenta);";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.VarChar) { Value = productoVendido.Stock });
                    comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVendido.IdProducto });
                    comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.VarChar) { Value = productoVendido.IdVenta });
                }
                conexion.Close();
            }
        }
        //Modificar producto vendido
        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "UPDATE ProductoVendido SET" +
                        "Stock = @Stock, " +
                        "IdProducto = @IdProducto, " +
                        "IdVenta = @IdVenta" +
                        "WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = productoVendido.IdProductoVendido });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.VarChar) { Value = productoVendido.Stock });
                    comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVendido.IdProducto });
                    comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.VarChar) { Value = productoVendido.IdVenta });
                }
                throw new Exception("Id no enocontrado");
                conexion.Close();
            }
        }
        //Eliminar producto vendido
        public static void EliminarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "DELETE FROM ProductoVendido WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = productoVendido.IdProductoVendido });
                }
                conexion.Close();
            }
        }
    }
}
