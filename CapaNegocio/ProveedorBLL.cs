using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using CapaEntidades;


namespace CapaNegocio
{
        public class ProveedorBLL
        {
            ProveedorDAL dal = new ProveedorDAL();

            public DataTable MostrarProveedores()
            {
                return dal.MostrarProveedores();
            }
        }
    }

