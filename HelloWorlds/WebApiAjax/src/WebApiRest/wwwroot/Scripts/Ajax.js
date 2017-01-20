window.addEventListener("load", start);
var personaSeleccionada;
var select;
var newWindow;
var newWindowPost;
var newWindowDetail;
function start() {
    document.getElementById("lista").addEventListener("click", listar);
    document.getElementById("borrar").addEventListener("click", borrar);
    document.getElementById("editar").addEventListener("click", editar);
    document.getElementById("nuevo").addEventListener("click", nuevo);
    document.getElementById("detalles").addEventListener("click", detail);
    listar();
}
//Para cuando Pulsa una persona en el select
function setPersonaSeleccionada() {
    document.getElementById("seccionBotones").style.display = "";
    var cadena = select.options[select.selectedIndex].text;
    var id = cadena.substring(0, cadena.indexOf(","));
    var oXML = new XMLHttpRequest();
    var url = "../api/personas/" + id;
    oXML.open("GET", url);
    oXML.onreadystatechange = function () {
        var respXML = oXML.response;
        if (oXML.readyState == 4 && oXML.status == 200) {
            var object = JSON.parse(oXML.responseText);
            personaSeleccionada = new Persona(object);
        }
    };
    oXML.send();
}
//Funcion que recoge todas las personas de la api
function listar() {
    if (select != null) {
        document.getElementById("contenedor").removeChild(select);
    }
    select = document.createElement("Select");
    var oXML = new XMLHttpRequest();
    oXML.open("GET", "../api/personas/");
    oXML.onreadystatechange = function () {
        var respXML = oXML.response;
        if (oXML.readyState == 4 && oXML.status == 200) {
            var arraypersonas = JSON.parse(oXML.responseText);
            select.addEventListener("change", setPersonaSeleccionada);
            select.multiple = "multiple";
            for (var i = 0; i < arraypersonas.length; i++) {
                var p = new Persona(arraypersonas[i]);
                var option = document.createElement("option");
                option.text = p.cadena();
                select.appendChild(option);
            }
        }
    };
    oXML.send();
    document.getElementById("contenedor").appendChild(select);
}
//Funcion para borrar a una persona
function borrar() {
    var r = confirm("Esta seguro de que quiere borrar a " + personaSeleccionada.cadena());
    var borrado = false;
    if (r == true) {
        var oXML = new XMLHttpRequest();
        oXML.open("DELETE", "../api/personas/" + personaSeleccionada.id);
        oXML.onreadystatechange = function () {
            if (oXML.readyState == 4 && oXML.status == 200) {
                personaSeleccionada = null;
                listar();
            }
        };
        oXML.send();
    }
}
function editar() {
    if (newWindowDetail != undefined) {
        newWindowDetail.close();
    }
    newWindow = window.open("Editar", "Editar", "status=yes,toolbar=no,menubar=no,location=no");
    newWindow.document.write("<H4> Editar a " + personaSeleccionada.nombre + "</H4>");
    newWindow.document.write("<p> Nombre: </p> <input type='text' id='nombre' value='" + personaSeleccionada.nombre + "'/>");
    newWindow.document.write("<p> Apellidos: </p> <input type='text' id='apellido' value='" + personaSeleccionada.apellido + "'/>");
    newWindow.document.write("<p> Fecha de nacimiento: </p> <input type='text' id='fechaNac' value='" + personaSeleccionada.fechaNac + "'/>");
    newWindow.document.write("<p> Direccion: </p> <input type='text' id='direccion' value='" + personaSeleccionada.direccion + "'/>");
    newWindow.document.write("<p> Telefono: </p> <input type='text' id='telefono' value='" + personaSeleccionada.telefono + "'/> <br/> <br/>");
    newWindow.document.write("<input type='button' id='editarlo' value='Editar' />");
    newWindow.document.getElementById("editarlo").addEventListener("click", generar);
}
function generar() {
    var r = false;
    r = confirm("Esta seguro de que quiere editar a " + personaSeleccionada.cadena());
    if (r == true) {
        //Es un PUT("EDIT")
        personaSeleccionada.nombre = newWindow.document.getElementById("nombre").value;
        personaSeleccionada.apellido = newWindow.document.getElementById("apellido").value;
        personaSeleccionada.fechaNac = newWindow.document.getElementById("fechaNac").value;
        personaSeleccionada.direccion = newWindow.document.getElementById("direccion").value;
        personaSeleccionada.telefono = newWindow.document.getElementById("telefono").value;
        var oXML = new XMLHttpRequest();
        oXML.open("PUT", "../api/personas/" + personaSeleccionada.id);
        oXML.setRequestHeader("Content-Type", "application/json");
        oXML.onreadystatechange = function () {
            if (oXML.readyState == 4 && oXML.status == 204) {
                personaSeleccionada = null;
                listar();
                newWindow.close();
            }
        };
        var json = JSON.stringify(personaSeleccionada);
        oXML.send(json);
    }
}
function nuevo() {
    newWindowPost = window.open("New", null, "status=yes,toolbar=no,menubar=no,location=no");
    personaSeleccionada = new Persona();
    newWindowPost.document.write("<H4> Añadir Una Persona</H4>");
    newWindowPost.document.write("<p> Nombre: </p> <input type='text' id='nombre' value='" + personaSeleccionada.nombre + "'/>");
    newWindowPost.document.write("<p> Apellidos: </p> <input type='text' id='apellido' value='" + personaSeleccionada.apellido + "'/>");
    newWindowPost.document.write("<p> Fecha de nacimiento: </p> <input type='text' id='fechaNac' value='1/1/1990'/>");
    newWindowPost.document.write("<p> Direccion: </p> <input type='text' id='direccion' value='" + personaSeleccionada.direccion + "'/>");
    newWindowPost.document.write("<p> Telefono: </p> <input type='text' id='telefono' value='" + personaSeleccionada.telefono + "'/> <br/> <br/>");
    newWindowPost.document.write("<input type='button' id='anadir' value='Añadir' />");
    newWindowPost.document.getElementById("anadir").addEventListener("click", post);
}
function post() {
    personaSeleccionada.setPersona(newWindowPost.document.getElementById("nombre").value, newWindowPost.document.getElementById("apellido").value, newWindowPost.document.getElementById("fechaNac").value, newWindowPost.document.getElementById("direccion").value, newWindowPost.document.getElementById("telefono").value);
    var r = confirm("Esta seguro de que quiere agregar a " + personaSeleccionada.nombre + " " + personaSeleccionada.apellido);
    if (r == true) {
        var oXMLpost = new XMLHttpRequest();
        oXMLpost.open("POST", "../api/personas/");
        oXMLpost.setRequestHeader("Content-Type", "application/json");
        oXMLpost.onreadystatechange = function () {
            if (oXMLpost.readyState == 4 && oXMLpost.status == 204) {
                personaSeleccionada = null;
                listar();
                newWindowPost.close();
            }
        };
        var jsonpost = JSON.stringify(personaSeleccionada);
        oXMLpost.send(jsonpost);
    }
}
function detail() {
    newWindowDetail = window.open("Detail", null, "status=yes,toolbar=no,menubar=no,location=no");
    newWindowDetail.document.write("<H4> Detalles de " + personaSeleccionada.nombre + "</H4>");
    newWindowDetail.document.write("<p> Nombre: </p> <p> " + personaSeleccionada.nombre + "</p>");
    newWindowDetail.document.write("<p> Apellidos: </p> <p>" + personaSeleccionada.apellido + "</p>");
    newWindowDetail.document.write("<p> Fecha de nacimiento: </p> <p>" + personaSeleccionada.fechaNac + "<p/>");
    newWindowDetail.document.write("<p> Direccion: </p> <p>" + personaSeleccionada.direccion + "</p>");
    newWindowDetail.document.write("<p> Telefono: </p> <p>" + personaSeleccionada.telefono + "</p> <br/> <br/>");
    newWindowDetail.document.write("<input type='button' id='editardetail' value='Editar' />");
    newWindowDetail.document.getElementById("editardetail").addEventListener("click", editar);
}
