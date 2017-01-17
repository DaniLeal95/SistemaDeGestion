window.addEventListener("load", start);
function start() {
    document.getElementById("lista").addEventListener("click", listar);
    document.getElementById("texto");
}
function listar() {
    var oXML = new XMLHttpRequest();
    oXML.open("GET", "../api/personas/");
    oXML.onreadystatechange = function () {
        var respXML = oXML.response;
        if (oXML.readyState == 4 && oXML.status == 200) {
            var arraypersonas = JSON.parse(oXML.responseText);
            for (var i = 0; i < arraypersonas.length; i++) {
                var p = new Persona(arraypersonas[i]);
                var select = document.getElementById("personas");
                var option = document.createElement("option");
                option.text = p.cadena();
                select.appendChild(option);
            }
        }
    };
    oXML.send();
}
