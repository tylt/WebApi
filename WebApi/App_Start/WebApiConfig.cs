using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Hangfire;
using Hangfire.SqlServer;
using Unity;
using DataAccess;
using DataAccess.Service;
using Unity.AspNet.WebApi;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //IOC container for dependency injection using Unit.ASP.net.Webapi
            var container = new UnityContainer();

            container.RegisterType<IDoctorService, DoctorService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            config.DependencyResolver = new UnityDependencyResolver(container);


            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
