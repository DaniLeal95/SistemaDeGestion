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

        public ActionResult Edit(int id)
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();
            clsPersona p = cmpb.getPersona(id);

            return View("Edit",p);
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

        //Metodo para detail
        
        public ActionResult Details(int id)
        {
            clsManejadoraPersonaBL detail = new clsManejadoraPersonaBL();
            
            clsPersona p = detail.getPersona(id);
            return View("Details", p);
        }

        public ActionResult Delete(int id)
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();
            clsPersona p = cmpb.getPersona(id);

            return View("Delete",p);
        }
        
        [HttpPost , ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            clsListadosPersonasBL listado = new clsListadosPersonasBL();
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();
            try
            {
                cmpb.deletePersona(id);
                return View("Index", listado.getListadoPersonaBL());
            }
            catch (Exception)
            {
                return View("Error");
            }
            
        

        }

    }
}