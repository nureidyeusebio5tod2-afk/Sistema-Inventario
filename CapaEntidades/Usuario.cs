using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    
        public class Usuario
        {
            public int Id_Usuario { get; set; }

            public string Nombre { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public int Id_Rol { get; set; }

            public DateTime Fecha_Creacion { get; set; }

            public bool Estado { get; set; }
        }
    }

