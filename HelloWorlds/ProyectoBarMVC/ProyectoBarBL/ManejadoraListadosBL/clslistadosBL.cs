
using ProyectoBarDAL.ListadosDAL;
using System.Collections.Generic;



namespace ProyectoBar
{
    public class clslistadosBL
    {
        //LLAMADA A DAL , Devuelve ARRAY DE PERSONAS (list)

        public IEnumerable<clsCliente> getListadoClientesBL()
        {
            return new clsListadosClientesDAL().getListadoPersonaDAL();
        }

    }
}
