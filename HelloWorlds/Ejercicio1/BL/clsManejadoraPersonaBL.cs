using Ejercicio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ejercicio1
{
    public class clsManejadoraPersonaBL
    {
        private clsManejadoraPersonaDAL cmpd;

        public clsManejadoraPersonaBL()
        {
             cmpd = new clsManejadoraPersonaDAL();
        }

       
        /// <summary>
        ///    Metodo para retornar una persona segun el id que nos pasen por parametros
        /// </summary>
        /// <param name="id">que hace referencia al campo principal de persona</param>
        /// <returns> Un Objeto persona asociado al nombre</returns>

        public clsPersona getPersona (int id)
        {
            clsPersona p;
            p = cmpd.getPersona(id);
            return p;
        }

        /// <summary>
        ///    Metodo para retornar un booleano que busque en la bbdd si hay una persona con ese id
        /// </summary>
        /// <param name="id">que hace referencia al campo principal de persona</param>
        /// <returns> Un booleano indicando si existe o no la persona con esa id</returns>

        public Boolean existePersona(int id)
        {
            Boolean haypersona;
            haypersona = cmpd.existePersona(id);
            return haypersona;
        }


    }
}
