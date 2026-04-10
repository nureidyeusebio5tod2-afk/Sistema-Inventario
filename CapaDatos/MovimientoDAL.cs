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

   
        public class MovimientoDAL
        {
            //INSERTAR MOVI
            public int InsertarMovimiento(Movimiento m)
            {
                int idMovimiento = 0;

                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Sp_Insertar_Movimiento", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Tipo_Movimiento", m.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@Id_Usuario", m.IdUsuario);

                cmd.Parameters.AddWithValue("@Id_Cliente",
                                          (object)m.IdCliente ?? DBNull.Value);


                cn.Open();

                    idMovimiento = Convert.ToInt32(cmd.ExecuteScalar());

                    cn.Close();
                }

                return idMovimiento;
            }

            //  INSERTAR DETALLE 
            public void InsertarDetalle(DetalleMovimiento d)
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Sp_Insertar_Detalle_Movimiento", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Movimiento", d.IdMovimiento);
                    cmd.Parameters.AddWithValue("@Id_Producto", d.IdProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }

          //Este metodo es para obtener el numero del mov
            public int ObtenerProximoMovimiento()
            {
                int numero = 0;
            // Aqui próximo número de movimiento automáticamente.
            using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Id_Movimiento),0)+1 FROM Movimientos", cn);

                    cn.Open();
                    numero = Convert.ToInt32(cmd.ExecuteScalar());
                    cn.Close();
                }

                return numero;
            }
        }
    }






