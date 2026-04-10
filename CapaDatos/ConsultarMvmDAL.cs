using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   
        public class ConsultarMvmDAL
        {
            public DataTable MostrarMovimientos()
            {
                DataTable tabla = new DataTable();

                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Sp_Mostrar_Movimientos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }

                return tabla;
            }
        }
    }

