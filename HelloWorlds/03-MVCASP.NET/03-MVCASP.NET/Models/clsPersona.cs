using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _03_MVCASP.NET.Models
{

  public class clsPersona
    {
        //propiedades y Getters/Setters
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }

        //constructores
        public clsPersona(String nombre, String apellido, int edad)
        {
            
            
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
           
        }

        public clsPersona()
        {
            this.nombre = null;
            this.apellido = null;
            this.edad = 0;
        }
        override
        public String ToString()
        {
            return ("Nombre: "+this.nombre+" , Apellidos: "+this.apellido+", Edad: "+this.edad);
        }
    }
}
