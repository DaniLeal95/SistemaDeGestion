using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVCASP.NET.Models
{
    public class clsListado
    {
       public List<clsPersona> list { get; set; }

        public clsListado()
        {
            list = new List<clsPersona>();
                list.Add(new clsPersona("Dani", "Leal" ,21));
            list.Add(new clsPersona("Dani", "Leal", 21));
            list.Add(new clsPersona("Gracias", "Leal", 21));
            list.Add(new clsPersona("Pepe", "Leal", 21));
            list.Add(new clsPersona("Rosi", "Leal", 21));
            list.Add(new clsPersona("JEJE", "Saludos", 21));

        }

       


        


    }
}