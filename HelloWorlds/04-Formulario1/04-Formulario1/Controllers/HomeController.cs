using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04_Formulario1.Models;

namespace _04_Formulario1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            clsListado oListadoPersonas = new Models.clsListado();
            return View(oListadoPersonas.list);
        }

        public ActionResult Indexcreate()
        {
            return View();
        }

        //Action Cuando se pulse submit
        [HttpPost]
        public ActionResult Indexcreate(clsPersona oPersona)
        {
            String vista;
            clsListado oListadoPersonas = new clsListado();

            if (ModelState.IsValid)
            {
                //Ingreasamos en la bbdd
                oListadoPersonas.list.Add(oPersona);
                
                vista = "Index";
            }
            else
            {
                vista = "";
            }

            return View(vista,oListadoPersonas.list);
        }



        
    }
}