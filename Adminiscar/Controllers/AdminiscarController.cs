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
        /*public ActionResult Index()
        {

            return View();

            
        }*/

        public string Index() {

            return "esse é minha pagina default action";

        }

        public string Welcome() {

            return "esse é meu method Welcome action";

        }
    }
}