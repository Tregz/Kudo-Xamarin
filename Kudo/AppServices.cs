using System;
using System.Collections.Generic;

namespace Kudo
{
    public sealed class ServiceLocator
    {
        static readonly Lazy<ServiceLocator> instance =
            new Lazy<ServiceLocator>(() => new ServiceLocator());
        readonly Dictionary<Type, Lazy<object>> services =
            new Dictionary<Type, Lazy<object>>();

        public static ServiceLocator Instance => instance.Value;

        public void Register<TContract, TService>() where TService : new() =>
            services[typeof(TContract)] = new Lazy<object>(() =>
            Activator.CreateInstance(typeof(TService)));

        public T Get<T>() where T : class
        {
            if (services.TryGetValue(typeof(T), out Lazy<object> service))
                return (T)service.Value;
            return null;
        }
    }
}
