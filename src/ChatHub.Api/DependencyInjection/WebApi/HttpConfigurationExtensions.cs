using ChatHub.Api.DependencyInjection;
using System.Web.Http.Dependencies;

namespace System.Web.Http
{
    public static class HttpConfigurationExtensions
    {
        public static HttpConfiguration UseDependencyInjection(this HttpConfiguration config, ChatHub.Api.DependencyInjection.IServiceProvider services)
        {
            config.DependencyResolver = services.GetService<IDependencyResolver>();
            return config;
        }
    }
}