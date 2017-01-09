document.getElementById("boton").addEventListener("click", saludo);

function saludo() {
  
        //alert("Version del navegador " + navigator.appVersion +" \n Nombre del navegador " +navigator.appName);
    //Para saber el nombre del navegador
    var navegador = navigator.userAgent;
    if (navigator.userAgent.indexOf('MSIE') != -1) {
        alert('está usando Internet Explorer ...');
    } else if (navigator.userAgent.indexOf('Firefox') != -1) {
        alert('está usando Firefox ...');
    } else if (navigator.userAgent.indexOf('Chrome') != -1) {
        alert('está usando Google Chrome ...');
    } else if (navigator.userAgent.indexOf('Opera') != -1) {
        alert('está usando Opera ...');
    } else {
        alert('está usando un navegador no identificado ...');
    }
    
    if (document.getElementById("nombre").value != "" && document.getElementById("apellido").value != "") {
        var texto = "Hola " + document.getElementById("nombre").value + " " + document.getElementById("apellido").value;

        document.getElementById("divMensaje").innerHTML = (texto);
    }


    if (document.getElementById("nombre").value == "") {
        document.getElementById("lblerrornombre").innerHTML = "El nombre debe estar relleno";
        document.getElementById("divMensaje").innerHTML = "";
    } else {
        document.getElementById("lblerrornombre").innerHTML = "";
        
    }
    if (document.getElementById("apellido").value == "") {
        document.getElementById("lblerrorapellido").innerHTML = "El apellido debe estar relleno";
        document.getElementById("divMensaje").innerHTML = "";
    } else {
        document.getElementById("lblerrorapellido").innerHTML = "";

    }
}