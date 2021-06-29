using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adminiscar.Models;
using Adminiscar.Dal;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace Adminiscar.Controllers
{
    public class AdminiscarController : Controller
    {

        /**
         * 
         * indexInicio
         * 
         * */

        public ActionResult Index()
        {
            return View();
        }

        //chamando o dal acoes do login
        acoesLogin acLg = new acoesLogin();

        [HttpPost]
        public ActionResult Index(LoginACS verLogin)
        {
            acLg.LogarUsuario(verLogin);    //pegando objeto login jogando os valores do method Logar

            //fazendo codição
            if (verLogin.user != null && verLogin.pass != null)
            {

                FormsAuthentication.SetAuthCookie(verLogin.user, false);    //ele não deve existir no cookie
                Session["usuarioLog"] = verLogin.user.ToString();   //criando a sesssoes
                Session["senhaLogado"] = verLogin.user.ToString();

                //criando o tipo
                if (verLogin.tipoUser == "0")
                {

                    Session["tipoLogado"] = verLogin.tipoUser.ToString();

                }
                else
                {

                    Session["tipoLogado1"] = verLogin.tipoUser.ToString();

                }

                return RedirectToAction("MenuInicial", "Adminiscar");

            }
            else {

                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                Response.Write("<script>alert('Erro no Login!!!')</script>");
                return View();

            }

        }
        //indexFim

        public ActionResult Loadding()
        {

            return View();


        }

        public ActionResult MenuInicial()
        {

            return View();


        }


        /**
         * 
         * Cliente
         * 
         * */
        List<Cliente> clientes = acoesCli.consultaCli();    //lista da consulta

        public ActionResult Cliente() {

            acoesCli acsCli = new acoesCli();    //chamando classe methods

            //dropList (Cadastro do cliente)
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "UF", Value = "0", Selected = true });

            items.Add(new SelectListItem { Text = "SP", Value = "1" });

            items.Add(new SelectListItem { Text = "RJ", Value = "2" });

            items.Add(new SelectListItem { Text = "ES", Value = "3" });

            ViewBag.UfType = items;
            //fimDroplist

            return View();  //retornando a view
        }

        //consultaCliente
        public ActionResult ConsultaCliente() {

            return View(clientes);

        }

        //detalhesCliente
        [HttpPost]
        public ActionResult DetalhesCliente(string teste) {

            acoesCli acsCli = new acoesCli();    //chamando classe methods do cliente

            //ViewBag.numeroDeIten = acsCli.detalheCli(cliente).Count();
            ViewBag.dadosCli = acsCli.detalheCli(teste);
            //ViewBag.testeCliente = teste;

            return View();

        }

        //busca cliente
        [HttpPost]
        public ActionResult BuscaCliente(string buscaData) {

            acoesCli acsCli = new acoesCli();    //chamando classe methods do cliente

            List<Cliente> cliente = acsCli.buscaCli(buscaData);

            return View(cliente);

        }

        //editarClienteView
        [HttpPost]
        public ActionResult EditarCliente(string editarCli) {
            acoesCli acsCli = new acoesCli();    //chamando classe methods do cliente

            ViewBag.codCli = editarCli;
            ViewBag.dadosCli = acsCli.detalheCli(editarCli);

            return View();

        }
        
        //fazendoEditandoDados
        public ActionResult UpdateCliente(Cliente cliente, string codCli) {

            acoesCli acoescli = new acoesCli();

            acoescli.EditarCli(cliente, codCli);

            return RedirectToAction("ConsultaCliente", "Adminiscar");

        }

        //cadastro do cliente
        [HttpPost]
        public ActionResult Cliente02(Cliente cliente) {

            acoesCli acoescli = new acoesCli();

            acoescli.cadastroCli(cliente);

            return RedirectToAction("Cliente", "Adminiscar");

        }

        //deletar o Cliente
        [HttpPost]
        public ActionResult DeletarCliente(string delCli) {

            acoesCli acoescli = new acoesCli();

            acoescli.DeleteCli(delCli);

            return RedirectToAction("ConsultaCliente", "Adminiscar");

        }
        /**
         * fimCliente
         * */


        /**
         * 
         * carroInicio
         * 
         * */
        public ActionResult Carro()
        {

            return View();
        }

        //Cadastro carro
        [HttpPost]
        public ActionResult CadastroCarro(Carro carro) {    //recebendo o objeto do cadastroCarro

            acoesCar acoescar = new acoesCar();

            acoescar.cadastroCar(carro);

            return RedirectToAction("Carro", "Adminiscar");
        }

        //Consulta carro
        public ActionResult ConsultaCarro()
        {

            List<Carro> listCarro = acoesCar.consultaCar();    //lista da consulta

            return View(listCarro);

        }

        //Detalhes carro
        [HttpPost]
        public ActionResult DetalheCarro(string codCar) {

            acoesCar acsCar = new acoesCar();   //chamando o method

            ViewBag.dadosCar = acsCar.detalheCar(codCar);

            return View();

        }

        //Editar carro
        public ActionResult EditarCarro(string editarCar) {

            acoesCar acsCar = new acoesCar();   //chamando o method

            ViewBag.codCar = editarCar; //codigo do car
            ViewBag.dadosCar = acsCar.detalheCar(editarCar); //dados do carro

            return View();

        }
        //editandoCarro
        [HttpPost]
        public ActionResult UpdateCarro(Carro car, string codCar) {

            acoesCar acoescar = new acoesCar();

            acoescar.updateCar(car, codCar);

            return RedirectToAction("ConsultaCarro", "Adminiscar");

        }

        //delatando carro
        public ActionResult DeleteCarro(string deletarCar) {

            acoesCar acsCar = new acoesCar();

            acsCar.deletarCar(deletarCar);

            return RedirectToAction("ConsultaCarro", "Adminiscar");

        }

        //carroFim

        /**
         * 
         * devolucaoInicio
         * 
         * */
        public ActionResult Devolucao()
        {

            return View();
        }
        //fimDevolucao

        /**
         * 
         * locacaoInicio
         * 
         * */
        public ActionResult Locacao()
        {
            //istaciando acoesLoc
            acoesLoc acsLoc = new acoesLoc();

            /*DropListas de veiculos*/
            int QtdItens = acsLoc.listVeiculoLoc().Count();
            var ListVec = acsLoc.listVeiculoLoc();
            var ListCod = acsLoc.listCodVecLoc();

            List<SelectListItem> itensVec = new List<SelectListItem>();

            itensVec.Add(new SelectListItem { Text = "Veiculo", Value = "0", Selected = true });

            var i = 0;

            while (i <= QtdItens - 1) {

                itensVec.Add(new SelectListItem { Text = ListVec[i], Value = ListCod[i] });

                i++;

            }
            /*FimDropListVeiculo*/


            ViewBag.Veiculos = itensVec;    //retornando na viewbag os dropList

            return View();
        }

        //pre Locacao do carro
        [HttpPost]
        public ActionResult AlugarConfirLoc(string clienteLoc, string cnpjLoc, string cpfLoc, string cnhLoc, string TellLoc, string cellLoc, string Veiculos, string som, string somBt, string gps, string dateLoc) {

            //chamando a classe com os methods
            acoesLoc acsLoc = new acoesLoc();

            //exibindo os valores
            ViewBag.dadosLoc = acsLoc.listLoc(clienteLoc, cnpjLoc, cpfLoc, cnhLoc, TellLoc, cellLoc, Veiculos, som, somBt, gps, dateLoc);

            return View();

        }

        //finalizando o pedido
        [HttpPost]
        public ActionResult FinalizandoPedido(string nomeCli, string cpfCli, string cnpjCli, string cnhCli, string codCar, string TellCli, string cellCli, string dateEnt, string valorTotal, string typePag) {
            //chamando method locacao
            acoesLoc acsLoc = new acoesLoc();

            acsLoc.finPedidoLoc(nomeCli, cpfCli, cnpjCli, cnhCli, codCar, TellCli, cellCli, dateEnt, valorTotal, typePag);

            return RedirectToAction("Locacao", "Adminiscar");

        }

        //Consulta Locacao
        public ActionResult ConsultaLocacao() {

            acoesLoc acsLoc = new acoesLoc();

            List<Locacao> listLocacao = acsLoc.consultaLocacaoLoc();    //retornando como lista

            return View(listLocacao);

        }

        //detalhes Locacao
        public ActionResult DetalhesLocacao(string codPedido) {

            acoesLoc acsLoc = new acoesLoc();   //chamando o method

            ViewBag.dadosLoc = acsLoc.detalheLocacaoLoc(codPedido);

            return View();

        }
    }
}