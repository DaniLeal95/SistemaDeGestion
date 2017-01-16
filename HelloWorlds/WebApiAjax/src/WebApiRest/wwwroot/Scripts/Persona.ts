class Persona {

     id: number;
     nombre: string;
     apellido: string;
     fechanac: Date;
     direccion: string;
     telefono: string;

     
     //constructor(id?: number, nombre?: string, apellido?: string, fechanac?: Date, direccion?: string, telefono?: string);
     constructor(persona?: any) {
     
         if (persona != null) {
             this.id = persona.id;
             this.nombre = persona.nombre;
             this.apellido = persona.apellido;
             this.fechanac = persona.fechanac;
             this.direccion = persona.direccion;
             this.telefono = persona.telefono;
         }
     
     }
    

    cadena() {
        let cadena: string;
        cadena = this.nombre + "," + this.apellido;
        return cadena;
    }
   
}
