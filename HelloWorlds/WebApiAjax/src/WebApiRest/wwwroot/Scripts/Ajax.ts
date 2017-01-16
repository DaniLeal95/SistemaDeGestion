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
        if (oXML.readyState == 4 && oXML.status == 200) {
        var arraypersonas:any[] = JSON.parse(oXML.responseText);

        for (let i: number = 0; i < arraypersonas.length; i++) {

            var p: Persona = new Persona(arraypersonas[i]);
        }
        

            


        document.getElementById("texto").innerHTML = "hola " + p.cadena();
        }

    }
    oXML.send();
}


