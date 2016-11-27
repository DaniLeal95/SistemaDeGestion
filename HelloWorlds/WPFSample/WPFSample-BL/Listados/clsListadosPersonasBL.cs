using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_Ent;
using WPFSample;


namespace WPFSample_BL.Listados
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
