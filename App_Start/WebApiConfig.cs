using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Configuration;

namespace Qualidade_web_api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();


            //Rota padrão
            string defaultRoutePrefix = String.Format("api/v0/");
            defaultRoutePrefix += "{controller}/{action}/{id}";

            //var corsAttr = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(corsAttr);

            config.Routes.MapHttpRoute(
                name: "ApiQualidade",
                routeTemplate: defaultRoutePrefix,
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
