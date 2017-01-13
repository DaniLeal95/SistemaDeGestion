var Persona = (function () {
    function Persona(id, nombre, apellido, fechanac, direccion, telefono) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechanac = fechanac;
        this.direccion = direccion;
        this.telefono = telefono;
    }
    return Persona;
}());
function cadena() {
    return "id: " + this.id + " ,nombre: " + this.nombre;
}
