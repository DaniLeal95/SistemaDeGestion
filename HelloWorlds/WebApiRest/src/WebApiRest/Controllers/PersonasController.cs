using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiRest;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    public class PersonasController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
           clsListadosPersonasBL bl = new clsListadosPersonasBL();

            return (bl.getListadoPersonaBL());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            clsManejadoraPersonaBL bl = new clsManejadoraPersonaBL();
            clsPersona p = bl.getPersona(id);
            if (p != null)
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 404;
            }

            return (p);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]clsPersona value)
        {

            clsManejadoraPersonaBL bl = new clsManejadoraPersonaBL();
            bl.insertPerson(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]clsPersona value)
        {
            value.id = id;
            clsManejadoraPersonaBL bl = new clsManejadoraPersonaBL();
            if (bl.updatePerson(value)==1)
            {
                Response.StatusCode = 204;
            }else
            {
                Response.StatusCode = 404;

            }
            
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            clsManejadoraPersonaBL bl = new clsManejadoraPersonaBL();

            bl.deletePersona(id);
        }
    }
}
