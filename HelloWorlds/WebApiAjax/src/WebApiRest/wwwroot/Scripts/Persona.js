var Persona = (function () {
    function Persona(persona) {
        if (persona != null) {
            this.id = persona.id;
            this.nombre = persona.nombre;
            this.apellido = persona.apellido;
            this.fechaNac = persona.fechaNac.substring(0, 10);
            this.direccion = persona.direccion;
            this.telefono = persona.telefono;
        }
    }
    Persona.prototype.cadena = function () {
        var cadena;
        cadena = this.id + "," + this.apellido + "," + this.nombre;
        return cadena;
    };
    return Persona;
}());
