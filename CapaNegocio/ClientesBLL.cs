using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{

        public class ClientesBLL
        {
            private ClientesDAL objDAL = new ClientesDAL();

         
            public DataTable MostrarClientes()
            {
                return objDAL.MostrarClientes();
            }

      
            public void InsertarCliente(Clientes cli)
            {
                if (string.IsNullOrEmpty(cli.Nombre))
                    throw new Exception("El nombre del cliente es obligatorio");

                objDAL.InsertarCliente(cli.Nombre, cli.Direccion, cli.Telefono, cli.Correo);
            }

            public void ActualizarCliente(Clientes cli)
            {
                if (cli.Id_cliente <= 0)
                    throw new Exception("Seleccione un cliente válido");

                objDAL.ActualizarCliente(
                    cli.Id_cliente,
                    cli.Nombre,
                    cli.Direccion,
                    cli.Telefono,
                    cli.Correo,
                    cli.Estado_cliente
                );
            }

            public void EliminarCliente(int id)
            {
                if (id <= 0)
                    throw new Exception("Seleccione un cliente válido");

                objDAL.EliminarCliente(id);
            }
       }
  }

