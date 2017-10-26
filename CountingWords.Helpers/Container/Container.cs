using CountingWords.Shared.Container;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace CountingWords.Helpers.Container
{
    /// <summary>
    /// Class responsible for implement the interface <see cref="IContainer"/>
    /// </summary>
    public class Container : IContainer
    {
        private IDependencyResolver _resolver;

        public Container(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }
        public T GetService<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);

        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)_resolver.GetServices(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }
    }
}
