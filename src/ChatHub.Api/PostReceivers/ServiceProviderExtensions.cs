using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.PostReceivers;

namespace ChatHub.Api.DependencyInjection
{
    public partial class ServiceProviderExtensions
    {
        public static IServiceProvider AddPostInterceptors(this IServiceProvider services)
        {
            services.AddImplementors<IPostInterceptor>();
            return services;
        }
    }
}