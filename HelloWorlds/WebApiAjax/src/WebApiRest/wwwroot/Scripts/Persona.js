var Persona = (function () {
    function Persona(persona) {
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
            this.fechaNac = new Date(1990, 1, 1);
            this.direccion = "";
            this.telefono = "";
        }
    }
    Persona.prototype.setid = function (id) {
        this.id = id;
    };
    Persona.prototype.setPersona = function (nombre, apellido, fechaNac, direccion, telefono) {
        this.id = -1;
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechaNac = fechaNac;
        this.direccion = direccion;
        this.telefono = telefono;
    };
    Persona.prototype.cadena = function () {
        var cadena;
        cadena = this.id + "," + this.apellido + "," + this.nombre;
        return cadena;
    };
    return Persona;
}());
