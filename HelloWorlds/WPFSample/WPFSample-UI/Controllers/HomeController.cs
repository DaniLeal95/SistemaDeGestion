using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFSample_BL;
using WPFSample_BL.Listados;
using WPFSample_Ent;

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


        //Metodos para Crear
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(clsPersona p)
        {
            int i;
            clsManejadoraPersonaBL createPersona = new clsManejadoraPersonaBL();
            clsListadosPersonasBL listado = new clsListadosPersonasBL();
            i = createPersona.insertPerson(p);

            return View("Index",listado.getListadoPersonaBL());
        }

        //Metodos para Actualizar

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(clsPersona p)
        {
            int i;
            clsManejadoraPersonaBL update = new clsManejadoraPersonaBL();
            clsListadosPersonasBL listado = new clsListadosPersonasBL();

            i = update.updatePerson(p);

            return View("Index",listado.getListadoPersonaBL());
        }


    }
}