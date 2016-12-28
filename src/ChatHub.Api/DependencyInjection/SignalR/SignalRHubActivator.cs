using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatHub.Api.DependencyInjection.SignalR
{
    public class SignalRHubActivator : IHubActivator
    {
        private readonly IServiceProvider _provider;
        public SignalRHubActivator(IServiceProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            _provider = provider;
        }

        public IHub Create(HubDescriptor descriptor)
        {
            return (IHub)_provider.GetService(descriptor.HubType);
        }
    }
}