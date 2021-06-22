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

        public ActionResult ConsultaCliente() {

            return View(clientes);

        }

        public ActionResult DetalhesCliente() {

            return View();

        }

        [HttpPost] //consulta cliente
        public ActionResult ConsultCliente3(Cliente cli) {

            acoesCli acsCli = new acoesCli();    //chamando classe methods

            //Consulta do cliente
            GridView dataGV = new GridView();   //Desenvolvendo instancia da tabela
            dataGV.DataSource = acsCli.buscCli(cli); //Atribuir ao grid o resultado da consulta
            dataGV.DataBind(); //confirmando o grid
            StringWriter sw = new StringWriter();   //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw);    //Comando para construção do Grid na tela
            dataGV.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela

            return View();

        }

        [HttpPost]  //cadastro do cliente
        public ActionResult Cliente02(Cliente cliente) {

            acoesCli acoescli = new acoesCli();

            acoescli.cadastroCli(cliente);

            return RedirectToAction("Cliente", "Adminiscar");

        }
        //clienteFim


        /**
         * 
         * carroInicio
         * 
         * */
        public ActionResult Carro()
        {

            return View();
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

            return View();
        }
        /*public string Index() {

            return "esse é minha pagina default action";

        }*/

        /*
         * no Aps.net os parametros da URL funciona desse jeito
         * nomeDoDominio/Controller/actionName/parametrosDeles
         * no arquivo _start/RouteConfig.cs vc define as routas da url
         * 
         **/

        /*public string Welcome() {

            return "esse é meu method Welcome action";

        }*/
    }
}