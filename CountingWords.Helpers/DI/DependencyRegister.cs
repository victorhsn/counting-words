using CountingWords.Domain.CommandHandlers;
using Unity;
using Unity.Lifetime;

namespace CountingWords.Helpers.DI
{
    /// <summary>
    /// Class responsible to register all classes that will be injected.
    /// </summary>
    public static class DependencyRegister
    {
        public static void Register(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<PhraseCommandHandler, PhraseCommandHandler>(new HierarchicalLifetimeManager());
        }
    }
}
