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
    public static class ProductoData
    {
        //Obtener producto
        public static List<Producto> ObtenerProducto(int IdProducto)
        {
            List<Producto> lista = new List<Producto>(); 
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, PrecioVenta, Stok, IdUsuario " +
                        "FROM Producto WHERE Id=@Id;";
        
            using(SqlConnection conexion = new SqlConnection(connectionString)) 
            { 
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion)) 
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdProducto;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader()) 
                    { 
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.IdProducto = Convert.ToInt32(dr["Id"]);
                                producto.Descripcion = dr["Descripciones"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(producto);
                            }
                            throw new Exception("Id no enocontrado");
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }
     
        //Listar productos
        public static List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, PrecioVenta, Stok, IdUsuario FROM Producto;";

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
                                var producto = new Producto();
                                producto.IdProducto = Convert.ToInt32(dr["Id"]);
                                producto.Descripcion = dr["Descripciones"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(producto);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            return lista;
        }
        //Crear producto
        public static void CrearProducto(Producto producto)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, idUsuario)" +
                        "VALUES(@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario);";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion});
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.VarChar) { Value = producto.Costo});
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.VarChar) { Value = producto.PrecioVenta});
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.VarChar) { Value = producto.Stock});
                    comando.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario});
                }
                conexion.Close();
            }
        }
        //Modificar producto
        public static void ModificarProducto(Producto producto)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "UPDATE Producto SET" +
                        "Descripciones = @Descripcion, " +
                        "Costo = @Costo , " +
                        "PrecioVenta = @PrecioVenta," +
                        "Stock = @Stock " +
                        "WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = producto.IdProducto} );
                    comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion});
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.VarChar) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.VarChar) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.VarChar) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario });
                }
                throw new Exception("Id no enocontrado");
                conexion.Close();
            }
        }
        //Eliminar producto
        public static void EliminarProducto(Producto producto)
        {
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;";
            var query = "DELETE FROM Producto WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = producto.IdProducto });
                }
                conexion.Close();
            }
        }
    }
}
