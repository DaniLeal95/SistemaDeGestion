using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRest;


namespace WebApiRest
{
   public class clsListadosPersonasBL
    {
        /// <summary>
        /// Funcion para que nos devuelva el listado de las personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public List<clsPersona> getListadoPersonaBL()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();

            clsListadosPersonasDAL listapersonas = new clsListadosPersonasDAL();

            listadoPersonas = listapersonas.getListadoPersonaDAL();

            return listadoPersonas;
        }


    }
}
