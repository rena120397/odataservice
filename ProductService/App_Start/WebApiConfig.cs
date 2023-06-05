using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProductService.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            builder.EntitySet<Product>("Products");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());

            //// Rutas de Web API
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
