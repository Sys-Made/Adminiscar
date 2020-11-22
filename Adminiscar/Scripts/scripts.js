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

/*LoaddingFucao*/
var i = 0;

function move() {
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

/*NavegacaoCadCon*/
function NavegacaoCadCon(value) {

    alert("teste funfou " + value);

}
/*fimNavegacaoCadCon/
