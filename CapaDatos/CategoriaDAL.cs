using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CategoriaDAL
    {
        //conexión en una variable tipo string
        private string cadena =
        ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        // ProcedimientoListarCategoria
        public List<Categorias> Listar()
        {
            List<Categorias> lista = new List<Categorias>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarCategorias", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Categorias c = new Categorias();

                    c.Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]);
                    c.Nombre = dr["Nombre"].ToString();
                    c.Estado = Convert.ToBoolean(dr["Estado"]);

                    lista.Add(c);
                }
            }

            return lista;
        }

        // insertarcat
        public void Insertar(Categorias c)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ACTUALIZARcat
        public void Actualizar(Categorias c)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Categoria", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINARCat
        public void Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Categoria", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
