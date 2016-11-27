using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPFSample_BL;
using WPFSample_BL.Listados;

namespace WPFSample_UI.Models
{
    public class VMclsListado
    {
        public clsListadosPersonasBL lista { get; set; }
        public int cantidad { get; set; }

        public VMclsListado()
        {
            this.lista = new clsListadosPersonasBL();
            cantidad = lista.getListadoPersonaBL().Count;
        }
    }
}