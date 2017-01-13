window.addEventListener("load", start);

function start() {
    document.getElementById("lista").addEventListener("click", listar);
    document.getElementById("texto");
    


}

function listar() {
    
    document.getElementById("texto").innerHTML = "esto va";
    var oXML = new XMLHttpRequest();
    oXML.open("GET", "../api/personas/");
    oXML.onreadystatechange = function () {
        var respXML = oXML.response;

        var arraypersonas = JSON.parse(oXML.responseText);

        let p = new Persona();

        p = arraypersonas[0];

        var cadena = p.cadena;

        document.getElementById("texto").innerHTML = "hola " +cadena;

    }
    oXML.send();
}