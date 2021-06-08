using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adminiscar.Models;
using Adminiscar.Dal;
using System.Web.Security;

namespace Adminiscar.Controllers
{
    public class AdminiscarController : Controller
    {

        //chamando o dal acoes do login
        acoesLogin acLg = new acoesLogin();

        [HttpPost]
        public ActionResult Index(LoginACS verLogin)
        {
            acLg.LogarUsuario(verLogin);    //pegando objeto login jogando os valores do method Logar

            //fazendo codição
            if (verLogin.user != null && verLogin.pass != null) {

                FormsAuthentication.SetAuthCookie(verLogin.user, false);    //ele não deve existir no cookie
                Session["usuarioLog"] = verLogin.user.ToString();   //criando a sesssoes
                Session["senhaLogado"] = verLogin.user.ToString();

                //criando o tipo
                if (verLogin.tipoUser == "0")
                {

                    Session["tipoLogado"] = verLogin.tipoUser.ToString();

                }
                else {

                    Session["tipoLogado1"] = verLogin.tipoUser.ToString();

                }

                return RedirectToAction("MenuInicial", "Home");

            }

            return View();

            
        }

        public ActionResult Loadding()
        {

            return View();


        }

        public ActionResult MenuInicial()
        {

            return View();


        }

        public ActionResult Cliente() {

            return View();
        }

        public ActionResult Carro()
        {

            return View();
        }

        public ActionResult Devolucao()
        {

            return View();
        }

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