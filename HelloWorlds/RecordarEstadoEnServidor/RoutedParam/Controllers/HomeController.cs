using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutedParam.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// Preguntamos por el routed data y lo mandamos a la vista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            
            ViewBag.contador = id;
            return View();
        }

        /// <summary>
        ///     Rediccionamos a Index con un routedData contador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost , ActionName("Index")]
        public ActionResult IndexPost(int? id)
        {
            id=(id == null) ?  0 : id + 1;
            return RedirectToAction("Index",new { id });
        }
    }
}