using _04_Formulario1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_Formulario1.Models
{
    public class clsListado
    {
       public List<clsPersona> list { get; set; }

        public clsListado()
        {
            list = new List<clsPersona>();
            list.Add(new clsPersona(1,"Dani", "Leal" ,21));
            list.Add(new clsPersona(2,"Rudo", "Garcia", 49));
            list.Add(new clsPersona(3,"Gracias", "De-nada", 89));
            list.Add(new clsPersona(4,"Pepe", "Botella", 210));
            list.Add(new clsPersona(5,"Rosi", "Paola", 12));
            list.Add(new clsPersona(6,"JEJE", "Saludos", 2));

        }

       


        


    }
}