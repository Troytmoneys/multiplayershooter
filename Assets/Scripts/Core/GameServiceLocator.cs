using System;
using System.Collections.Generic;

namespace BrawlShooter.Core
{
    /// <summary>
    /// Lightweight service locator to keep runtime singletons out of MonoBehaviours.
    /// </summary>
    public static class GameServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<TService>(TService instance)
        {
            var type = typeof(TService);
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance), $"Cannot register a null service for {type.Name}");
            }

            _services[type] = instance;
        }

        public static bool TryResolve<TService>(out TService instance)
        {
            if (_services.TryGetValue(typeof(TService), out var boxed) && boxed is TService typed)
            {
                instance = typed;
                return true;
            }

            instance = default!;
            return false;
        }

        public static TService Resolve<TService>()
        {
            if (TryResolve<TService>(out var instance))
            {
                return instance;
            }

            throw new InvalidOperationException($"Service {typeof(TService).Name} has not been registered.");
        }

        public static void Clear() => _services.Clear();
    }
}
