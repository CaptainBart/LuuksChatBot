using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace ChatHub.Api.DependencyInjection
{
    public class UnityServiceProvider : IServiceProvider
    {
        public UnityServiceProvider() : this(new UnityContainer())
        { }

        public UnityServiceProvider(IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            this.Container = container;
            this.Container.RegisterInstance<IServiceProvider>(this);
        }

        public IUnityContainer Container { get; }

        public void AddTransient<TFrom, TTo>(string name = null) where TTo : TFrom
        {
            if (String.IsNullOrEmpty(name))
            {
                this.Container.RegisterType<TFrom, TTo>(new TransientLifetimeManager());
            }
            else
            {
                this.Container.RegisterType<TFrom, TTo>(name, new TransientLifetimeManager());
            }
        }

        public void AddTransient<TFrom>(Type to, string name = null)
        {
            if (String.IsNullOrEmpty(name))
            {
                this.Container.RegisterType(typeof (TFrom), to, new TransientLifetimeManager());
            }
            else
            {
                this.Container.RegisterType(typeof(TFrom), to, name, new TransientLifetimeManager());
            }
        }

        public void AddSingleton<TFrom, TTo>() where TTo : TFrom
        {
            this.Container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }

        public void AddSingleton<TFrom>(TFrom instance)
        {
            this.Container.RegisterInstance<TFrom>(instance, new ContainerControlledLifetimeManager());
        }

        public void AddTransient<TFrom>(Func<IServiceProvider, object> factoryFunc)
        {
            this.Container.RegisterType<TFrom>(new TransientLifetimeManager(), new InjectionFactory((c) => factoryFunc(new UnityServiceProvider(c))));
        }

        public T GetService<T>()
        {
            return this.Container.Resolve<T>();
        }

        public object GetService(Type t)
        {
            return this.Container.Resolve(t);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return this.Container.ResolveAll<T>();
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return this.Container.ResolveAll(t);
        }

        public bool HasService(Type t)
        {
            return this.Container.IsRegistered(t);
        }

        public IServiceProvider CreateChildContainer()
        {
            var childContainer = this.Container.CreateChildContainer();
            return new UnityServiceProvider(childContainer);
        }

        public void Dispose()
        {
           this.Container.Dispose();
        }
    }   
}