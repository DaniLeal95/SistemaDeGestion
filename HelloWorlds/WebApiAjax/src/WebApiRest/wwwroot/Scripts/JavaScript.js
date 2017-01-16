
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
            var arraypersonas = JSON.parse(oXML.responseText);

            let persona2 = new Persona2(1,"dani","leal","12/10/1995","eee","3232");
           // persona2 = arraypersonas[0];
            
                
            console.log(persona2.cadena());
            // enseñarPersona(persona);

            // var cadena: string = p.cadena();
            
            //document.getElementById("texto").innerHTML = "hola " + cadena;
        }

    }
    oXML.send();
}