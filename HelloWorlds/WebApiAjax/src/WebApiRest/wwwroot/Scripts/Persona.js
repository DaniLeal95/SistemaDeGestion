var Persona = (function () {
    function Persona(persona) {
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
    Persona.prototype.cadena = function () {
        var cadena;
        cadena = this.id + "," + this.apellido + "," + this.nombre;
        return cadena;
    };
    return Persona;
}());
