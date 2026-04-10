using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class ProductoDAL
    {
        //
        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("Sp_Mostrar_Productos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // 
        public void InsertarProducto(Producto obj)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open(); 

                SqlCommand cmd = new SqlCommand("sp_InsertarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                cmd.Parameters.AddWithValue("@Id_Categoria", obj.Id_Categoria);
                cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);

                cmd.ExecuteNonQuery();
            }
        }

        //
        public void ActualizarProducto(Producto obj)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open(); 

                SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Producto", obj.Id_Producto);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                cmd.Parameters.AddWithValue("@Id_Categoria", obj.Id_Categoria);
                cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);

                cmd.ExecuteNonQuery();
            }
        }

        // 
        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open(); 

                SqlCommand cmd = new SqlCommand("sp_EliminarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Producto", idProducto);

                cmd.ExecuteNonQuery();
            }
        }

        // 
        public DataTable ListarProveedores()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarProveedores", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}