using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFSample_BL;
using WPFSample_BL.Listados;
using WPFSample_Ent;
using WPFSample_UI.Models;

namespace WPFSample_UI.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            VMclsListado listado = new VMclsListado();
            try
            {
                return View(listado);
            }
            catch (Exception)
            {
                return View("Error");
            }

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
            i = createPersona.insertPerson(p);
            //VMclsListado listado = new VMclsListado();
            
            return RedirectToAction("Index");
        }

        //Metodos para Actualizar

        public ActionResult Edit(int id)
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();
            clsPersona p = cmpb.getPersona(id);

            return RedirectToAction("Edit",p);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(clsPersona p)
        {
            int i;
            clsManejadoraPersonaBL update = new clsManejadoraPersonaBL();
            clsListadosPersonasBL listado = new clsListadosPersonasBL();

            i = update.updatePerson(p);

            return RedirectToAction("Index");
        }

        //Metodo para detail
        
        public ActionResult Details(int id)
        {
            clsManejadoraPersonaBL detail = new clsManejadoraPersonaBL();
            clsPersona p;
            try
            {
                 p = detail.getPersona(id);
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Details", p);
        }
        /// <summary>
        /// Es la primera vez que entra al delete, recoge la id de la url.
        /// </summary>
        /// <param name="id">recoge el parametro de la url</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();
            clsPersona p;
            try
            {
                p = cmpb.getPersona(id);
            }
            catch (Exception)
            {
                return View("Error"); 

            }
            

            return View("Delete",p);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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