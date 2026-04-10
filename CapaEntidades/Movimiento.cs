using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
        public class Movimiento
        {
        
            public int IdMovimiento { get; set; }
            public string TipoMovimiento { get; set; }
            public DateTime Fecha { get; set; }
            public int IdUsuario { get; set; }

         
            public int? IdCliente { get; set; }
        }
    }
    

