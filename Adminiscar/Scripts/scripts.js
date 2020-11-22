/*LoaddingFucao*/
var i = 0;

var move = function() {
    if (i == 0) {
        i = 1;
        var elem = document.getElementById("myBar");
        var width = 1;
        var id = setInterval(frame, 10);
        function frame() {
            if (width >= 100) {
                clearInterval(id);
                i = 0;
            } else {
                width++;
                elem.style.width = width + "%";
            }
        }
    }
}
/*fimLoadingFuncao*/

/*FuncaoNavegacaoDoMenuinicial*/
var NavFuncao = function (valueHtml) {
    //convertendo em numero ineteiro
    var valuePg = parseInt(valueHtml);

    switch (valuePg) {

        case 1:
            location.href = "Cliente";
            break;

        case 2:
            location.href = "Carro";
            break;

        case 3:
            location.href = "Locacao";
            break;

        case 4:
            location.href = "Devolucao";
            break;

        default:
            alert("Error01!! NA FUNÇÃO -> NavFuncao() Ou essa Pagina não existe");
            break;

    }
    //alert("Hello" + valueHtml);

};
/*fimFuncaoNavegacaoDoMenuinicial*/

/*NavegacaoCadCon*/
var NavegacaoCadCon = function (value) {
    //declarando variaveis
    var numSecaoInfo, btnCadastro, btnConsulta, guardaList,testeLocation;

    //convertendo para inteiro
    numSecaoInfo = parseInt(value);

    //colocando as classeNames em uma variavel
    btnCadastro = document.getElementsByClassName("botaoCadastro");

    if (numSecaoInfo == 1) {

        testeLocation = btnCadastro[0].classList;

        guardaList = testeLocation.toString();

        alert(guardaList.indexOf("butaoActive"));

        //alert(testeLocation.indexOf("wewe"));

        /*guardaList = btnCadastro[0].classList;

        testeLocation = guardaList.indexOf("butaoActive");*/


        //alert(btnCadastro[0].classList);

        //alert(testeLocation);

    }

    //alert("teste funfou " + value);

};
/*fimNavegacaoCadCon*/