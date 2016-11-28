using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ENT;
using Ejercicio2;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        ///     Este ActionResult se ejecutara cuando el usuario ejecute la solucion,
        ///        
        /// </summary>
        /// <returns> retornara la vista con el listado de nombres de categorias, si hay algun error retornara la vista de error</returns>
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                clsListadosCategoriasBL cmpb = new clsListadosCategoriasBL();
               
                ProductVM productos = new ProductVM();
                productos.categorias= cmpb.getListadoCategoriaBL();



                return View("Index",productos);
            }
            catch (Exception)
            {
                return View("Error");
            }

            
        }

       


        /// <summary>
        ///  Este actionresult se ejecutara cuando el usuario pulse el boton guardar de la vista,
        ///     insertara un producto en la bbdd y volvera a generar la lista de categorias,
        ///     si hay algun error ira a la vista de error
        /// </summary>
        /// <param name="p"> producto a insertar en la bbdd</param>
        /// <returns> Retornara la vista Index, si hay algun error retornara la vista Error</returns>
        [HttpPost, ActionName("Index")]
        public ActionResult IndexPersonaInlude(ProductVM p)
        {
            Producto prod = new Producto(p.idCategoria, p.nombreProducto);
            try
            {
                if (p.nombreProducto != null)
                {

                    clsManejadoraProductoBL cmpb = new clsManejadoraProductoBL();
                    
                    cmpb.insertProduct(prod);
                    return View("Index");
                }
                else
                {
                    return View("Error");
                }

                
                
            }
            catch (Exception)
            {
                return View("Error");

            }

           
        }
    }
}