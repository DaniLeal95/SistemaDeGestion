﻿class Persona {

     id: number;
     nombre: string;
     apellido: string;
     fechaNac: string;
     direccion: string;
     telefono: string;

     
     
     constructor(persona?: any) {
     
         if (persona != null) {
             


             this.id = persona.id;
             this.nombre = persona.nombre;
             this.apellido = persona.apellido;
             this.fechaNac = persona.fechaNac.substring(0,10);
             
             this.direccion = persona.direccion;
             this.telefono = persona.telefono;
         }
     
     }
    

    cadena() {
        let cadena: string;
        cadena = this.id + "," + this.apellido + "," + this.nombre;
        return cadena;
    }
   
}
