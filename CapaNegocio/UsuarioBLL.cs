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

    public class UsuarioBLL
    {
        UsuarioDAL dal = new UsuarioDAL();

        public void Registrar(Usuario u)
        {
            dal.Registrar(u);
        }

        public DataTable Listar()
        {
            return dal.Listar();
        }
        public DataTable Login(string username, string password)
        {
            return dal.Login(username, password);
        }
    }
}



