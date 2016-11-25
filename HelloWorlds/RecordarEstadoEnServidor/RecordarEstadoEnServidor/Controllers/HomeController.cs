using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordarEstadoEnServidor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  Segun el value del boton, cuyo name sea boton, hará una funcion determinada
        ///  
        /// </summary>
        /// <param name="boton"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(String boton, String usuario)
        {
            switch (boton)
            {
                case "sumar":
                    Session["contador"] = Convert.ToInt32(Session["contador"]) + 1;
                    break;
                case "cerrarSesion":
                    Session.Clear();
                    Session.Abandon();
                    break;
                case "Log in":
                    Session["usuario"] = usuario;
                    break;
            }
            return View();
        }
    }
}