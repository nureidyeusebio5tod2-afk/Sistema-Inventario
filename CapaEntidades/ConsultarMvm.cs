using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   
        public class ConsultarMvm
        {
            public int Id_Movimiento { get; set; }
            public string Tipo_Movimiento { get; set; }
            public DateTime Fecha { get; set; }
            public string Usuario { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
        }
    }

