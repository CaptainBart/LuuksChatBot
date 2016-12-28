using System.Threading.Tasks;
using System.Web.Http;
using ChatHub.Api.DependencyInjection;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(ChatHub.Api.Startup))]

namespace ChatHub.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var services = new UnityServiceProvider();
            this.ConfigureServices(services);
            this.Configure(app, services);
        }

        private void ConfigureServices(IServiceProvider services)
        {
            services.AddMvc();
            services.AddSignalR();
            services.AddRepositories();
            services.AddHubs();
            services.AddPostInterceptors();
            services.AddRobots();
        }

        private void Configure(IAppBuilder app, IServiceProvider services)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureWebApi(app, services);
            ConfigureSignalR(app, services);
        }

        private void ConfigureWebApi(IAppBuilder app, IServiceProvider services)
        {
            HttpConfiguration config = new HttpConfiguration();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.UseDependencyInjection(services);
            app.UseWebApi(config);
        }

        private void ConfigureSignalR(IAppBuilder app, IServiceProvider services)
        {
            var config = new HubConfiguration();
            config.UseDependencyInjection(services);
            config.UseLowerCamlCase();
            app.MapSignalR(config);
        }
    }
}