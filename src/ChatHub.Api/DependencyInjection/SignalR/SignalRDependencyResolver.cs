using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;

namespace ChatHub.Api.DependencyInjection
{
    public class SignalRDependencyResolver : DefaultDependencyResolver
    {
        private readonly IServiceProvider _provider;
        public SignalRDependencyResolver(IServiceProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            _provider = provider;
        }

        public override object GetService(Type serviceType)
        {
            try
            {
                return _provider.GetService(serviceType);
            }
            catch (Exception)
            {
                return base.GetService(serviceType);
            } 
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _provider.GetServices(serviceType);
            }
            catch (Exception)
            {
                return base.GetServices(serviceType);
            }
        }
    }
}