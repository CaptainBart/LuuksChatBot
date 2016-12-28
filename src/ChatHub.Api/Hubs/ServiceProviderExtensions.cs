using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using ChatHub.Api.DependencyInjection.WebApi;
using ChatHub.Api.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace ChatHub.Api.DependencyInjection
{
    public static partial class ServiceProviderExtensions
    {
        public static IServiceProvider AddHubs(this IServiceProvider services)
        {
            services.AddHubContext<PostsHub, IChatClient>();

            return services;
        }

        
    }
}