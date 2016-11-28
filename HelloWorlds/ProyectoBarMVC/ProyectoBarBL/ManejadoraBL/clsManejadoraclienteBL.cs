
using ProyectoBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBarDAL;


namespace ProyectoBarBL
{
  public class clsManejadoraclienteBL
    {
        /*LLAMADA A FUNCIONES DAL PARA MANEJAR PERSONAS CON RESTICCIONES SEGUN 
            PRETENDA LA EMPRESA.
         */

        public int insertaClienteBL(clsCliente cliente)
        {

            clsManejadoraClienteDAL manejadora = new clsManejadoraClienteDAL();
            int res=manejadora.insertClient(cliente);

            return res;
        }

        public int deleteClient(int id)
        {

            clsManejadoraClienteDAL manejadora = new clsManejadoraClienteDAL();
            int res = manejadora.deleteClient(id);

            return res;
        }


        public int updateClient(clsCliente cliente)
        {

            clsManejadoraClienteDAL manejadora = new clsManejadoraClienteDAL();
            int res = manejadora.updateClient(cliente);

            return res;
        }


        public clsCliente getClient(int id)
        {

            clsManejadoraClienteDAL manejadora = new clsManejadoraClienteDAL();
            clsCliente res = manejadora.getClient(id);

            return res;
        }

    }
}
