using _006WebAPI_WithEF_AND_MVC.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml.Serialization;

namespace _006WebAPI_WithEF_AND_MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.Formatters.XmlFormatter.SetSerializer<Student>(
            //    new XmlSerializer(typeof(Student)));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);


            config.Formatters.Add(new BrowserJsonFormatter());
        }
    }
}
