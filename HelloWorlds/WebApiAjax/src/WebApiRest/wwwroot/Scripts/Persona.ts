class Persona {

     id: number;
     nombre: string;
     apellido: string;
     fechanac: Date;
     direccion: string;
     telefono: string;
    

    constructor(id: number, nombre: string, apellido: string, fechanac: Date, direccion: string, telefono: string) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechanac = fechanac;
        this.direccion = direccion;
        this.telefono = telefono;
     
     }

       function cadena(): string {
    return "id: " + this.id + " ,nombre: " + this.nombre;
}
   
}