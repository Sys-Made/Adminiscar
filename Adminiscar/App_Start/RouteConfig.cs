using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Adminiscar
{
    public class RouteConfig
    {
        /*
         * 
         * Quando vc nao coloca nenhum parametro na URL ele utiliza um caminho padrão
         * a primeira parte da url determina o controlador que seria nesse caso
         * /Adminiscar que esta sendo mapeado pelo AdminiscarController.
         * então a URL ficaria assim /Controller/actionName/Parameters
         * igual a htpp://dominio/Adminiscar/Welcome
         * 
         * 
         * */

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
