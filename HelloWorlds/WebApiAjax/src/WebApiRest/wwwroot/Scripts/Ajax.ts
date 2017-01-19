window.addEventListener("load", start);


var personaSeleccionada;
var select;
var newWindow;

function start() {

    document.getElementById("lista").addEventListener("click", listar);
    document.getElementById("borrar").addEventListener("click", borrar);
    document.getElementById("editar").addEventListener("click", editar);
    listar();

}


//Para cuando Pulsa una persona en el select
function setPersonaSeleccionada() {

    document.getElementById("borrar").style.display = "block";
    document.getElementById("editar").style.display = "block";

    
    


    
    //AUNQUE ESTE EN ROJO SI VA (PORQUE ES TYPESCRIPT)
    var cadena: string = select.options[select.selectedIndex].text;
    var id: string = cadena.substring(0, cadena.indexOf(","));
    

    var oXML = new XMLHttpRequest();
    var url: string = "../api/personas/" + id;
    oXML.open("GET", url);

    oXML.onreadystatechange = function () {

        var respXML = oXML.response;

        if (oXML.readyState == 4 && oXML.status == 200) {
            var object = JSON.parse(oXML.responseText);

            personaSeleccionada = new Persona(object);
           
        }
    }
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

            var arraypersonas: any[] = JSON.parse(oXML.responseText);

            select.addEventListener("change", setPersonaSeleccionada);
            select.multiple = "multiple";


            for (let i: number = 0; i < arraypersonas.length; i++) {

                var p: Persona = new Persona(arraypersonas[i]);

                var option = document.createElement("option");

                option.text = p.cadena();

                select.appendChild(option);

            }


        }
        

    }
    oXML.send();
    document.getElementById("contenedor").appendChild(select);
}



//Funcion para borrar a una persona

function borrar() {
    
    var r = confirm("Esta seguro de que quiere borrar a " + personaSeleccionada.cadena());
    var borrado: boolean = false;
    if (r == true) {

        
       var oXML = new XMLHttpRequest();
        oXML.open("DELETE", "../api/personas/" + personaSeleccionada.id);
        oXML.onreadystatechange = function () {

            if (oXML.readyState == 4 && oXML.status == 200) {

                
                    personaSeleccionada = null;
                    listar();
                
            }

        }
       oXML.send();
        
    }





}


function editar() {

    newWindow = window.open("Editar", null, "status=yes,toolbar=no,menubar=no,location=no");
    var datestring=personaSeleccionada.fechaNac.toString();
    
    newWindow.document.write("<H4>" + personaSeleccionada.nombre + "</H4>");
    
    newWindow.document.write("<p> Nombre: </p> <input type='text' id='nombre' value='" + personaSeleccionada.nombre+"'/>");
    newWindow.document.write("<p> Apellidos: </p> <input type='text' id='apellido' value='" + personaSeleccionada.apellido + "'/>");
    newWindow.document.write("<p> Fecha de nacimiento: </p> <input type='text' id='fechaNac' value='" + datestring + "'/>");
    newWindow.document.write("<p> Direccion: </p> <input type='text' id='direccion' value='" + personaSeleccionada.direccion + "'/>");
    newWindow.document.write("<p> Telefono: </p> <input type='text' id='telefono' value='" + personaSeleccionada.telefono + "'/> <br/> <br/>");
    newWindow.document.write("<input type='button' id='editarlo' value='Editar' />");
    newWindow.document.getElementById("editarlo").addEventListener("click", generar);



} 

function generar() {
    var r = confirm("Esta seguro de que quiere editar a " + personaSeleccionada.cadena());
    
    if (r == true) {
        
       
        personaSeleccionada.nombre = newWindow.document.getElementById("nombre").value;
        personaSeleccionada.apellido = newWindow.document.getElementById("apellido").value;
        personaSeleccionada.fechaNac = newWindow.document.getElementById("fechaNac").value;
        var dateFormat = require('dateformat');
        dateFormat(personaSeleccionada.fechaNac, "yyyy-mm-dd hh:MM:ss");
        personaSeleccionada.direccion = newWindow.document.getElementById("direccion").value;
        personaSeleccionada.telefono = newWindow.document.getElementById("telefono").value;

        

        var oXML = new XMLHttpRequest();

        oXML.open("PUT", "../api/personas/" + personaSeleccionada.id);
        oXML.setRequestHeader("Content-Type", "application/json");
        oXML.onreadystatechange = function () {

            if (oXML.readyState == 4 && oXML.status == 200) {


                personaSeleccionada = null;
                listar();
                newWindow.close();

            }

        }

        var json = JSON.stringify(personaSeleccionada);

        oXML.send(json);

    }


}


