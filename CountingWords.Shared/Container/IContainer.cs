using System;
using System.Collections.Generic;

namespace CountingWords.Shared.Container
{
    /// <summary>
    /// Interface to define methods used at Container
    /// </summary>
    public interface IContainer
    {
        T GetService<T>();
        object GetService(Type serviceType);
        IEnumerable<T> GetServices<T>();
        IEnumerable<object> GetServices(Type serviceType);
    }
}
