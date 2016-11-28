using Ejercicio2;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ejercicio2
{
   public class clsListadosCategoriasBL
    {
        /// <summary>
        ///      Funcion para que nos devuelva el listado de las personas que lo recoge de la Capa DAL
        /// </summary>
        /// <returns>un List con Listado de categorias</returns>
        public List<Categoria> getListadoCategoriaBL()
        {
            List<Categoria> listadoCategorias = new List<Categoria>();

            clsListadosCategoriasDAL listapersonas = new clsListadosCategoriasDAL();

            listadoCategorias = listapersonas.getListadoPersonaDAL();

            return listadoCategorias;
        }

    }
}
