using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using ChatHub.Api.DependencyInjection.WebApi;

namespace ChatHub.Api.DependencyInjection
{
    public static partial class ServiceProviderExtensions
    {
        public static IServiceProvider AddMvc(this IServiceProvider services)
        {
            services.AddSingleton<IDependencyResolver, WebApiDependencyResolver>();
            return services;
        }
    }
}