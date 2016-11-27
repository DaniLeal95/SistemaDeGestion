using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBar
{
   public class clsCliente
    {
        public int id { get; set; }
        public String nombre { get; set; }
        //FORMATO DE FECHA
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        //TIPO PARA CHROME
        //SELECTOR DE FECHA
        [DataType(DataType.Date)]
        ////NOMBRE ?¿?¿?
        public DateTime fechaNac { get; set; }
        
        

        [Required]
        public String apellido { get; set; }

        [Required]
        public String direccion { get; set; }

        [Required]
        public String telefono { get; set; }

        

        public clsCliente(int id, String nombre, String apellido, DateTime fechaNac, string direccion, string telefono)
        {

            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public clsCliente()
        {
            this.id = 1;
            this.nombre = "";
            this.apellido = "";
            this.fechaNac = new DateTime();
            this.direccion = "";
            this.telefono = "";
        }
        

        

        
    

    }
}
