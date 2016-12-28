using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace ChatHub.Api.DependencyInjection
{
    public interface IServiceProvider : IDisposable
    {
        void AddTransient<TFrom, TTo>(string name = null) where TTo : TFrom;
        void AddTransient<TFrom>(Type to, string name = null);
        void AddTransient<TFrom>(Func<IServiceProvider, object> factoryFunc);
        void AddSingleton<TFrom, TTo>() where TTo : TFrom;
        void AddSingleton<TFrom>(TFrom instance);
        T GetService<T>();
        object GetService(Type t);
        IEnumerable<T> GetServices<T>();
        IEnumerable<object> GetServices(Type t);
        bool HasService(Type t);
        IServiceProvider CreateChildContainer();
    }

    public static partial class ServiceProviderExtensions
    {
        public static void AddImplementors<TFrom>(this IServiceProvider services)
        {
            var baseType = typeof (TFrom);
            IEnumerable<Type> types =
            from a in AppDomain.CurrentDomain.GetAssemblies()
            from t in a.GetTypes()
            select t;

            var allTypes = types.ToList();

            var derivedTypes = allTypes.Where(t => baseType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
            foreach (var derivedType in derivedTypes)
            {
                services.AddTransient<TFrom>(derivedType, derivedType.FullName);
            }
        }
    }
}