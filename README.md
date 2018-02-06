# Asp DotNet Mvc Owin Starter

Start by creating a new .Net MVC Application

![New Project](Images/create_project.png?raw=true "Create Empty Project")

Let's pick Empty as we will add the needed packages ourselves.

![Select Empty](Images/empty_template.png?raw=true "Pick Empty")

`
install-package Microsoft.AspNet.Mvc
`

`
 install-package Microsoft.AspNet.WebApi.WebHost
 `

 `
 install-package Microsoft.AspNet.WebApi.Owin
 `

 `
 install-package Microsoft.Owin.Host.SystemWeb
 `

 Add Startup.cs class and decorate the Namespace with the OwinStartup Attribute.
![Owin Startup](Images/startup_cs.png?raw=true "Startup")

 `
 [assembly: OwinStartup(typeof(OwinMvcBoilerplate.Startup))]
 `

 Create App_Start folder and add RouteConfig.cs and WebApiConfig.cs files to it.

![App_Start](Images/app_start.png?raw=true "Startup")

 Following are the most basic configuration needed on those two files. 

 **RouteConfig.cs**
```
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
}
```

**WebApiConfig.cs**
```
public static void Register(HttpConfiguration config)
{
    config.MapHttpAttributeRoutes();
    config.Routes.MapHttpRoute(
        name: "DefaultApi",
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
    );
}
```
Add Controllers folder under the solution and an Empty MVC5 Controller. The Controller comes with empty Index method.

![Add Controller](Images/controllers.png?raw=true "Startup")

Add a view Just by Rigth clicking on the Index action method. Note when you do this, it also adds Bootstrap and jQuery as a dependency in your project along with _ViewStart.cshtml and _Layout.cshtml files with bootstrap auto configured.

![Add View](Images/add_view.png?raw=true "Add View")

Add a web.config file under your Views folder and copy content from the template here. **Make sure to update the Assembly Versions of the MVC in case it is different from what I have here.**

Finally update your **Startup.cs** class as below. This basically wires up everything at the start of the application. This is the replacement of your Global.asax file.

```
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
```

Hit F5 and you should see a nice Index page as below. 

![Run the app](Images/running_app.png?raw=true "Running App")

