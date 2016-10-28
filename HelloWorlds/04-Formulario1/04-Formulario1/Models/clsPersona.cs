using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _04_Formulario1.Models
{

  public class clsPersona
    {
        //propiedades y Getters/Setters
        public int id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String apellido { get; set; }
        public int edad { get; set; }

        //constructores
        public clsPersona(int id,String nombre, String apellido, int edad)
        {

            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
           
        }

        public clsPersona()
        {
            this.id = 1;
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
