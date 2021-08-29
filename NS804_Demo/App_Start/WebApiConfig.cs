using Newtonsoft.Json.Serialization;
using NS804_Demo.Secutiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NS804_Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            GlobalConfiguration.Configuration
                                .Formatters
                                .JsonFormatter
                                .SerializerSettings
                                .ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);



            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
