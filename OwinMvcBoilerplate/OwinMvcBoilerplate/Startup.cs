using Microsoft.Owin;
using Owin;
using OwinMvcBoilerplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(OwinMvcBoilerplate.Startup))]
namespace OwinMvcBoilerplate
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Register Areas
            AreaRegistration.RegisterAllAreas();
            //Register Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Create new HttpConfiguration
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            //Register WebAPI Routes
            WebApiConfig.Register(httpConfiguration);

            //Have OWIN app use WebAPI with new configurtaion
            app.UseWebApi(httpConfiguration);
        }
    }
}