/*LoaddingFucao*/

var move = function () {

    var i = 0;

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

        case 7:
            location.href = "MenuInicial";
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
    //declarando variaveis locais
    var numSecaoInfo, btnCadastro, secaoCadastro, secaoConsulta, btnConsulta, guardaList, guardaItem,testeLocation;

    //convertendo para inteiro
    numSecaoInfo = parseInt(value);

    //colocando as classeNames dos botoes em uma variavel
    btnCadastro = document.getElementsByClassName("botaoCadastro");
    btnConsulta = document.getElementsByClassName("botaoConsulta");
    secaoCadastro = document.getElementsByClassName("cadastroSecao");
    secaoConsulta = document.getElementsByClassName("consultaSecao");

    switch (numSecaoInfo) {

        case 1:
            //fazendo uma lista de class name com o method classList
            testeLocation = btnCadastro[0].classList;

            //Convertendo em String e buscando className especifico
            guardaList = testeLocation.toString();

            guardaList = guardaList.indexOf("butaoActive");

            //Convertendo para numero inteiro
            guardaItem = parseInt(guardaList);

            //vereficando se tem o butaoActive
            if (guardaItem == -1) {

                //mudando os nome da class de elemento para outro
                btnCadastro[0].classList.add("butaoActive");
                btnConsulta[0].classList.remove("butaoActive");
                secaoCadastro[0].classList.remove("noVisive");
                secaoConsulta[0].classList.add("noVisive");

            }
            break;

        case 2:
            //fazendo uma lista de class name com o method classList
            testeLocation = btnConsulta[0].classList;

            //Convertendo em String e buscando className especifico
            guardaList = testeLocation.toString();

            guardaList = guardaList.indexOf("butaoActive");

            //Convertendo para numero inteiro
            guardaItem = parseInt(guardaList);

            //verificando se não existe o butonActive
            if (guardaItem == -1) {

                btnConsulta[0].classList.add("butaoActive");
                btnCadastro[0].classList.remove("butaoActive");
                secaoConsulta[0].classList.remove("noVisive");
                secaoCadastro[0].classList.add("noVisive");

            }
            break;
            

        default:
            alert("Erro02! Na Função -> NavegacaoCadCon");

    }

};
/*fimNavegacaoCadCon*/

function teste() {

    alert("funfou");


}