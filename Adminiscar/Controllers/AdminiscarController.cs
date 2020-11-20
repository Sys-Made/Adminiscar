using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adminiscar.Controllers
{
    public class AdminiscarController : Controller
    {
        // GET: Adminiscar
        public ActionResult Index()
        {

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