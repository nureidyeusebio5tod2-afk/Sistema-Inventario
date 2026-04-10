using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
   
        public class Conexion
        {
            private static string cadena =
                ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            public static SqlConnection ObtenerConexion()
            {
                return new SqlConnection(cadena);
            }
        }
    }


