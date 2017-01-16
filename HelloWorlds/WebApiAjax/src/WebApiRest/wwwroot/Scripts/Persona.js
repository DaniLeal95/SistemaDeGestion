var Persona = (function () {
    //constructor(id?: number, nombre?: string, apellido?: string, fechanac?: Date, direccion?: string, telefono?: string);
    function Persona(persona) {
        if (persona != null) {
            this.id = persona.id;
            this.nombre = persona.nombre;
            this.apellido = persona.apellido;
            this.fechanac = persona.fechanac;
            this.direccion = persona.direccion;
            this.telefono = persona.telefono;
        }
    }
    Persona.prototype.cadena = function () {
        var cadena;
        cadena = this.nombre + "," + this.apellido;
        return cadena;
    };
    return Persona;
}());
