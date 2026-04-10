using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
        public class ClientesDAL
        {
            // MOSTRAR CLIENTES
            public DataTable MostrarClientes()
            {
                SqlConnection con = Conexion.ObtenerConexion();
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Clientes", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();
                return dt;
            }

            //  INSERTAR CLIENTE
            public void InsertarCliente(string nombre, string direccion, string telefono, string correo)
            {
                SqlConnection con = Conexion.ObtenerConexion();
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Correo", correo);
            cmd.Parameters.AddWithValue("@Estado", true);

            cmd.ExecuteNonQuery();
                con.Close();
            }

            //  ACTUALIZAR CLIENTE
            public void ActualizarCliente(int id, string nombre, string direccion, string telefono, string correo, string estado)
            {
                SqlConnection con = Conexion.ObtenerConexion();
                con.Open();

                SqlCommand cmd = new SqlCommand("SP_ActualizarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_cliente", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Estado_cliente", estado);

                cmd.ExecuteNonQuery();
                con.Close();
            }

            //  ELIMINAR CLIENTE
            public void EliminarCliente(int id)
            {
                SqlConnection con = Conexion.ObtenerConexion();
                con.Open();

                SqlCommand cmd = new SqlCommand("SP_EliminarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_cliente", id);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

