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
             this.fechaNac = persona.fechaNac;
             this.direccion = persona.direccion;
             this.telefono = persona.telefono;

         }
         else {
             this.id = -1;
             this.nombre = "";
             this.apellido = "";
             this.fechaNac = new Date(1990,1,1);
             this.direccion = "";
             this.telefono = "";


         }
     
     }

     setid(id: number) {
         this.id = id;
     }

     setPersona(nombre: string, apellido: string, fechaNac: Date, direccion: string, telefono: string) {
         this.id = -1;
         this.nombre = nombre;
         this.apellido = apellido;
         this.fechaNac = fechaNac;
         this.direccion = direccion;
         this.telefono = telefono;

     }


    cadena() {
        let cadena: string;
        cadena = this.id + "," + this.apellido + "," + this.nombre;
        return cadena;
    }
   
}
