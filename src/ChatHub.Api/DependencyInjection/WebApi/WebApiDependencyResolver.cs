using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;

namespace ChatHub.Api.DependencyInjection.WebApi
{
    public class WebApiDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _provider;
        private SharedDependencyScope _sharedScope;

        public WebApiDependencyResolver(IServiceProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            _provider = provider;
            _sharedScope = new SharedDependencyScope(this._provider);
        }
        
        public object GetService(Type serviceType)
        {
            try
            {
                return _provider.GetService(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _provider.GetServices(serviceType);
            }
            catch (Exception)
            {
                return new object[] {};
            }
        }

        public IDependencyScope BeginScope()
        {
            return _sharedScope;
        }

        public void Dispose()
        {   
            _provider.Dispose();
            _sharedScope.Dispose();
        }

        private sealed class SharedDependencyScope : IDependencyScope
        {
            private IServiceProvider _provider;

            public SharedDependencyScope(IServiceProvider provider)
            {
                _provider = provider;
            }

            public object GetService(Type serviceType)
            {
                try
                {
                    return _provider.GetService(serviceType);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return _provider.GetServices(serviceType);
                }
                catch (Exception)
                {
                    return new object[] { };
                }
            }

            public void Dispose()
            {
                // NO-OP, as the container is shared.
            }
        }
    }

    

}