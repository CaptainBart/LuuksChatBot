using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.DependencyInjection.SignalR;
using ChatHub.Api.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace Microsoft.AspNet.SignalR
{
    public static partial class ServiceProviderExtensions
    {
        public static HubConfiguration UseDependencyInjection(this HubConfiguration config, ChatHub.Api.DependencyInjection.IServiceProvider services)
        {
            var activator = new SignalRHubActivator(services);
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => activator);
            return config;
        }

        public static HubConfiguration UseLowerCamlCase(this HubConfiguration config)
        {
            config.Resolver.Register(typeof (JsonSerializer), () =>
            {
                var settings = new JsonSerializerSettings {ContractResolver = new SignalRContractResolver()};
                var serializer = JsonSerializer.Create(settings);
                return serializer;
            });

            return config;
        }
    }
}