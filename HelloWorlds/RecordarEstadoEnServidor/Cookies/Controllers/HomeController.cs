using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!Request.Cookies.AllKeys.Contains("contador"))
            {
                HttpCookie cookie = new HttpCookie("contador", "0");

                cookie.Expires = DateTime.Now.AddDays(7);

                Response.Cookies.Add(cookie);
                ViewBag.contador = 0;

            }
            else
            {
                HttpCookie cookie = Request.Cookies["contador"];
                ViewBag.contador =  Convert.ToInt32(cookie.Value);
               // Response.SetCookie(cookie);
            }

            return View();
        }
        /// <summary>
        ///     Cuando el usuario pulse el boton
        /// </summary>
        /// <returns></returns>
        [HttpPost,ActionName("Index")]
        public ViewResult IndexPost()
        {
            HttpCookie cookie = Request.Cookies["contador"];
            ViewBag.contador = Convert.ToInt32(cookie.Value);
            cookie.Value = (Convert.ToInt32(cookie.Value) + 1).ToString();

            Response.SetCookie(cookie);
            


            return View();
        }
    }
}