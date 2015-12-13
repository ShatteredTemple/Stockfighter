using System;
using System.Collections.Generic;
using System.Linq;
using FallenTemple.Stockfighter.Common.Repositories;

namespace FallenTemple.Stockfighter.StockExchange
{
    /// <summary>
    /// Class allowing the consumer to automatically wire up our offerings.
    /// </summary>
    public sealed class DependencyInjector
    {
        private static Dictionary<Type, Type> s_Interfaces;

        /// <summary>
        /// Define all interfaces that this assembly implements.
        /// </summary>
        DependencyInjector()
        {
            s_Interfaces = new Dictionary<Type, Type>()
            {
                { typeof(IStockExchange), typeof(StockExchange) }
            };
        }

        /// <summary>
        /// Gets a list of all interfaces that this assembly implements.
        /// </summary>
        /// <returns>Returns a list of all interfaces that this assembly implements.</returns>
        public static IReadOnlyDictionary<Type, Type> GetImplementedInterfaces()
        {
            // Clone it so we don't accidentally leak our internals.
            return s_Interfaces.ToDictionary(k => k.Key, v => v.Value);
        }

        /// <summary>
        /// Gets the implementation of a specific interface.
        /// </summary>
        /// <param name="interfaceToGet">Interface to return implementation of.</param>
        /// <returns>Type of the implementation, or null if not implemented.</returns>
        public static Type GetImplementation(Type interfaceToGet)
        {
            if (s_Interfaces.ContainsKey(interfaceToGet))
            {
                return s_Interfaces[interfaceToGet];
            }
            return null;
        }
    }
}
