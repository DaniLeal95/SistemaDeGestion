using Ejercicio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        ///     Usara esta vista cuando ejecute la solucion y retornara una vista index
        /// </summary>
        /// <returns>retornara una Vista</returns>
        public ActionResult Index()
        {


            return View("Index");
        }
        /// <summary>
        ///  Se llamara a este metodo cuando el usuario pulse el boton en la vista Index,
        ///     recogera el entero con el id
        /// </summary>
        /// <returns>La vista detalles con los detalles de la persona o la vista error si no hay ninguno con esa id</returns>
        [HttpPost]
        public ActionResult Index(String detail,String ids,String nick)
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();

            if (nick != null || ids!=null)
            {

                try
                {
                    int id = Convert.ToInt32(ids);
                    if (cmpb.existePersona(id))
                    {
                        Session["nick"] = nick;
                        clsPersona p;

                        p = cmpb.getPersona(id);


                        return View("Details", p);
                    }
                    else
                    {
                        //Si no existe el usuario
                        return View("Error");
                    }

                }
                //Si hay algun fallo en los metodos capa dal
                catch
                {

                    return View("Error");
                }
            }else
            {
                //Si no ha introducido los campos
                return View("Error");
            }
        }


  
    }
}