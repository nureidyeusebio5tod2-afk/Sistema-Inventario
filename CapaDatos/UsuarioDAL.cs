using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{

        public class UsuarioDAL
        {
            
            public void Registrar(Usuario u)
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Sp_Registrar_Usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
                    cmd.Parameters.AddWithValue("@Username", u.Username);
                    cmd.Parameters.AddWithValue("@Password", u.Password);
                    cmd.Parameters.AddWithValue("@Id_Rol", u.Id_Rol);
                    cmd.Parameters.AddWithValue("@Estado", u.Estado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

      
            public DataTable Listar()
            {
                DataTable tabla = new DataTable();

                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Sp_Mostrar_Usuarios", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }

                return tabla;
            }


   
        public DataTable Login(string username, string password)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("Sp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
 }

