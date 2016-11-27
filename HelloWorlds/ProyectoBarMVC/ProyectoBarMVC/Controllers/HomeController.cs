using ProyectoBar;
using ProyectoBarBL;
using System.Web.Mvc;

namespace ProyectoBarMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult listado()
        {
            clsManejadoraclienteBL manejadora = new clsManejadoraclienteBL();


            clslistadosBL lista = new clslistadosBL();



            return View("listado", lista.getListadoClientesBL());

        }
        [HttpPost]
        public ActionResult listado(string cerrarsesion)
        {
            
            Session.Clear();
            Session.Abandon();
            return View("Index");
        }
     
  
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                Session.Clear();
                Session.Abandon();
            }
            return View("Index");
        }


        [HttpPost]
        public ActionResult Index(string validar,string usuario)
        {


            clslistadosBL listado = new clslistadosBL();
          
                if (usuario.Equals("Dani"))
                {
                    Session["usuario"] = usuario;
                    return View("listado", listado.getListadoClientesBL());
                }
                else
                {
                    return View("Error");
                }
            }
           
        

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            clsCliente cliente;
            try { 
                clsManejadoraclienteBL manejadora = new clsManejadoraclienteBL();
                cliente =manejadora.getClient(id);
                return View("Details", cliente);
            }
            catch
            {
                return View("Error");
            }

            

        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(clsCliente cliente)
        {
            //if el cliente no es valido
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            else
            {
                try
                {
                    clsManejadoraclienteBL manejadora = new clsManejadoraclienteBL();

                    manejadora.insertaClienteBL(cliente);
                    clslistadosBL lista = new clslistadosBL();



                    return View("listado", lista.getListadoClientesBL());
                }
                catch
                {
                    return View("Error");
                }
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                clsManejadoraclienteBL manejadora = new clsManejadoraclienteBL();
                clsCliente cliente = manejadora.getClient(id);

                return View("Edit",cliente);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCliente cliente)
        {
            try
            {
                // TODO: Add update logic here
                clsManejadoraclienteBL manejadora = new clsManejadoraclienteBL();
                manejadora.updateClient(cliente);
                clslistadosBL lista = new clslistadosBL();


                return View("listado",lista.getListadoClientesBL());
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                clsManejadoraclienteBL manejadora = new clsManejadoraclienteBL();
                clsCliente cliente = manejadora.getClient(id);
                return View("Delete", cliente);
            }
            catch
            {
                return View("Error");
            }


            
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                clsManejadoraclienteBL manejadora = new clsManejadoraclienteBL();
                manejadora.deleteClient(id);
                clslistadosBL lista = new clslistadosBL();

                return View("listado",lista.getListadoClientesBL());
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
