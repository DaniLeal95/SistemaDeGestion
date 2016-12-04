﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AplicacionRepasoExamen
{
    /// <summary>
    ///  Clase Persona
    ///     Atributos: id, nombre, apellido, fechaNac, direccion, telefono 
    /// </summary>
  public class clsPersona
    {
        //propiedades y Getters/Setters
        public int id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String apellido { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        

        //constructores
        //con parametros
        public clsPersona(int id,String nombre, String apellido, DateTime fechaNac, string direccion, string telefono)
        {

            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;

           
        }
        //sin parametros
        public clsPersona()
        {
            this.id = 1;
            this.nombre = "";
            this.apellido = "";
            this.fechaNac =new DateTime();
            this.direccion = "";
            this.telefono = "";
        }

        //Fin constructores

        override
        public String ToString()
        {
            return ("Nombre: "+this.nombre+" , Apellidos: "+this.apellido+", Edad: "+this.fechaNac.ToString()+
                ", Direccion: "+this.direccion+", Telefono: "+this.telefono);
        }
    }
}
