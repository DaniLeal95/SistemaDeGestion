using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WPFSample_BL.Listados;

namespace WPFSample_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            clsListadosPersonasBL listado = new clsListadosPersonasBL();


            return View(listado.getListadoPersonaBL());
        }
    }
}