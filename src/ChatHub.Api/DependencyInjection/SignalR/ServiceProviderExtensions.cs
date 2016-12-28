using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.DependencyInjection.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Configuration;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNet.SignalR.Tracing;
using Newtonsoft.Json;

namespace ChatHub.Api.DependencyInjection
{
    public static partial class ServiceProviderExtensions
    {
        public static IServiceProvider AddSignalR(this IServiceProvider services, bool useLowerCamlCase = false)
        {
            services.AddSingleton<IDependencyResolver>(GlobalHost.DependencyResolver);
            services.AddSingleton<IConfigurationManager>(GlobalHost.Configuration);
            services.AddSingleton<IHubPipeline>(GlobalHost.HubPipeline);
            services.AddSingleton<ITraceManager>(GlobalHost.TraceManager);
            services.AddSingleton<IConnectionManager>(GlobalHost.ConnectionManager);

            if (useLowerCamlCase)
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new SignalRContractResolver();
                var serializer = JsonSerializer.Create(settings);
                services.AddSingleton<JsonSerializer>(serializer);
            }

            return services;
        }

        public static IServiceProvider AddHubContext<THub, THubClient>(this IServiceProvider services) where THub : IHub where THubClient : class
        {
            services.AddTransient<IHubContext<THubClient>>((s) => s.GetService<IConnectionManager>().GetHubContext<THub, THubClient>());
            return services;
        }
    }
}