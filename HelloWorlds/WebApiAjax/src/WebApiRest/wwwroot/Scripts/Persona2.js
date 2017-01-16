class Persona2 {
    

    constructor(id, nombre, apellidos, fechaNac, direccion, telefono) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNac = fechaNac;
        this.direccion = direccion;
        this.telefono = telefono;
    }

     cadena(){
        return this.nombre + "," + this.apellidos;
    }
}