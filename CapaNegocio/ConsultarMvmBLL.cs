using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaNegocio
{

    public class ConsultarMvmBLL
    {
        public DataTable MostrarMovimientos()
        {
            SqlConnection con = Conexion.ObtenerConexion();

            SqlDataAdapter da = new SqlDataAdapter("Sp_Mostrar_Movimientos", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
    
