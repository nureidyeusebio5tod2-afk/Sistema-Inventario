using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
        public class DetalleMovimiento
        {
            public int IdDetalle { get; set; }
            public int IdMovimiento { get; set; }
            public int IdProducto { get; set; }
            public int Cantidad { get; set; }
        }
    }

