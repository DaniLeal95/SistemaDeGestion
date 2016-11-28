


using Ejercicio2;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{

   public class clsManejadoraProductoBL
    {
        public clsManejadoraProductoDAL cmpd;

        public clsManejadoraProductoBL()
        {
            cmpd = new clsManejadoraProductoDAL();
        }

        /// <summary>
        ///     Inserta un producto que nos pasan por parametros
        /// </summary>
        /// <param name="producto"> Nos pasan un producto </param>
        /// <returns>-1 en caso de que hubiera fallo
        ///         1 en caso de que todo fuera correcto</returns>
        public int insertProduct(Producto producto)
        {
            int resultado = -1;
            resultado = cmpd.insertPersona(producto);
            return resultado;
        }


    }
}
