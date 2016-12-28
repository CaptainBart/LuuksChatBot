using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using ChatHub.Api.DependencyInjection.WebApi;
using ChatHub.Api.Repositories;

namespace ChatHub.Api.DependencyInjection
{
    public static partial class ServiceProviderExtensions
    {
        public static IServiceProvider AddRepositories(this IServiceProvider services)
        {
            services.AddSingleton<IPostRepository, PostRepository>();
            return services;
        }
    }
}