using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
        public class MovimientoBLL
        {
            MovimientoDAL dal = new MovimientoDAL();

            public int GuardarMovimiento(Movimiento m)
            {
                if (string.IsNullOrEmpty(m.TipoMovimiento))
                    throw new Exception("Debe seleccionar el tipo de movimiento");

                if (m.IdUsuario <= 0)
                    throw new Exception("Usuario no válido");

              
                
                return dal.InsertarMovimiento(m);
            }

            public void GuardarDetalle(DetalleMovimiento d)
            {
                if (d.IdProducto <= 0)
                    throw new Exception("Producto no válido");

                if (d.Cantidad <= 0)
                    throw new Exception("La cantidad debe ser mayor a 0");

                dal.InsertarDetalle(d);
            }

          
            public int ObtenerProximoMovimiento()
            {
                return dal.ObtenerProximoMovimiento();
            }
        }
    }


