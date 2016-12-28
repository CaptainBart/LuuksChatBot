using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.PostReceivers;
using ChatHub.Api.Robots;

namespace ChatHub.Api.DependencyInjection
{
    public partial class ServiceProviderExtensions
    {
        public static IServiceProvider AddRobots(this IServiceProvider services)
        {
            services.AddImplementors<IRobot>();
            return services;
        }
    }
}