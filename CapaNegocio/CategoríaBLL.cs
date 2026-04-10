using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{

    public class CategoriaBLL
    {
        private CategoriaDAL dal = new CategoriaDAL();

        public List<Categorias> Listar()
        {
            return dal.Listar();
        }

        public void Guardar(Categorias c)
        {
            if (c.Id_Categoria == 0)
                dal.Insertar(c);
            else
                dal.Actualizar(c);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
    }
}

