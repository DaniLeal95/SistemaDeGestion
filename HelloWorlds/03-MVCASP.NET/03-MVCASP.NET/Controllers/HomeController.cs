using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03_MVCASP.NET.Models;

namespace _03_MVCASP.NET.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Nombre"] = "Dani";
            ViewData["Apellidos"]="Leal";
            ViewBag.Nombrebag = "PEPE";
            ViewBag.Apellidos = "PAPA";

            clsPersona yo = new clsPersona("Dani", "Leal", 21);

            
            return View(yo);
        }
        //GET: Home
        public ActionResult Indexlistado()
        {
            clsListado lista = new clsListado();
            
            return View(lista.list);
        }
    }
}