document.getElementById("btnpeticion").addEventListener("click", llamada);
document.getElementById("btnpeticiondesplegable").addEventListener("click", llamada2);
document.getElementById("btnpedirPersonas").addEventListener("click", llamada3);

function llamada() {
    //Instanciamos un objeto XMLHttpRequest
    var oXML = new XMLHttpRequest();

    //Definimos el metodo OPEN
    oXML.open("GET", "../Server/Holamundo.html");

    //Definimos cabeceras //SOLO PUT-POST

    //Definir que hacemos cuando va cambiando el estado

    oXML.onreadystatechange = function () {
        if (oXML.status == 200) {

            if (oXML.status < 4) {
                document.getElementById("txtcontenedor").innerHTML = "Cargando...";

            }
            else {
                //Trabajamos con los datos
                document.getElementById("txtcontenedor").innerHTML = oXML.responseText;
            }
        }
        else {
            document.getElementById("txtcontenedor").innerHTML = "ERROR...";
        }

        
    }

    //Enviar la solicitud


    oXML.send();
}


//Recibir select desde servidor
function llamada2() {
    //Instanciamos un objeto XMLHttpRequest
    var oXML = new XMLHttpRequest();

    //Definimos el metodo OPEN
    oXML.open("GET", "../Server/Desplegable.html");

    //Definimos cabeceras //SOLO PUT-POST

    //Definir que hacemos cuando va cambiando el estado

    oXML.onreadystatechange = function () {
        if (oXML.status == 200) {

            if (oXML.status < 4) {
                document.getElementById("select").innerHTML = "Cargando...";

            }
            else {
                //Trabajamos con los datos
                document.getElementById("select").innerHTML = oXML.responseText;
            }
        }
        else {
            document.getElementById("select").innerHTML = "ERROR...";
        }


    }

    //Enviar la solicitud


    oXML.send();
}

function llamada3(){
        //Instanciamos un objeto XMLHttpRequest
    var oXML = new XMLHttpRequest();

    //Definimos el metodo OPEN
    oXML.open("GET", "../Server/listaPersonas.xml");

    //Definimos cabeceras //SOLO PUT-POST

    //Definir que hacemos cuando va cambiando el estado

    oXML.onreadystatechange = function () {
        if (oXML.status == 200) {

            if (oXML.status < 4) {
                document.getElementById("personas").innerHTML = "Cargando...";

            }
            else {
                //Trabajamos con los datos
                
                var respXML = oXML.responseXML;
                escribePersonas(respXML);
            }
        }
        else {
            document.getElementById("personas").innerHTML = "ERROR...";
        }


    }

    //Enviar la solicitud


    oXML.send();
}

function escribePersonas(respXML) {

    var personas=(respXML.getElementsByTagName("persona"));
    
    //var numPersonas=respXML.getElementsByTagName("personas")[0].;
    //alert(numPersonas);
    //var tabla = document.getElementById("personas");
    for (var i = 0 ; i < personas.length; i++) {
        //alert(i);
        
        var tabla = document.getElementById("personas");
        if(i==0){
            var row = tabla.insertRow(i);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            cell1.innerHTML = "Nombre";
            cell2.innerHTML = "Apellidos";

           }
        var row = tabla.insertRow(i + 1);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);

        //alert(personas[i].getElementsByTagName("nombre")[0].childNodes[0].nodeValue);
        //alert(personas[i].getElementsByTagName("apellidos")[0].childNodes[0].nodeValue);
        cell1.innerHTML = personas[i].getElementsByTagName("nombre")[0].childNodes[0].nodeValue;
        cell2.innerHTML = personas[i].getElementsByTagName("apellidos")[0].childNodes[0].nodeValue;
    }

   // document.getElementById("personas").innerHTML =respXML.getElementsByTagName("nombre")[0].childNodes[0].nodeValue;
}