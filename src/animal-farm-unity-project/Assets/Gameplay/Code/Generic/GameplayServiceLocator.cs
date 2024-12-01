using System;
using System.Collections.Generic;

namespace Gameplay.Generic
{
    public static class GameplayServiceLocator
    {
        private static readonly Dictionary<Type, object> Services = new();

        public static void Register<T>(T service)
        {
            var type = typeof(T);
            if (!Services.TryAdd(type, service))
                throw new InvalidOperationException($"Service of type {type} is already registered.");
        }

        public static void Unregister<T>()
        {
            var type = typeof(T);
            if (Services.ContainsKey(type)) 
                Services.Remove(type);
        }

        public static T Get<T>()
        {
            var type = typeof(T);
            if (Services.TryGetValue(type, out var service))
                return (T)service;
            
            throw new InvalidOperationException($"Service of type {type} is not registered.");
        }
    }
}