class Persona {

     id: number;
     nombre: string;
     apellido: string;
     fechaNac: Date;
     direccion: string;
     telefono: string;

     
     
     constructor(persona?: any) {
     
         if (persona != null) {
             
             

             this.id = persona.id;
             this.nombre = persona.nombre;
             this.apellido = persona.apellido;
             /*this.fechaNac = persona.fechaNac.toString().slice(0, 19).replace("T", " "),
                  = [d.getMonth() + 1,
                     d.getDate(),
                     d.getFullYear()].join('/') + ' ' +
                 [d.getHours(),
                     d.getMinutes(),
                     d.getSeconds()].join(':');*/


             
             
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
