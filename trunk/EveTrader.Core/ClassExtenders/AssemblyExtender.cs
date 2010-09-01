using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EveTrader.Core.ClassExtenders
{
    public static class AssemblyExtender
    {
        /// <summary>
        /// Extender to easily grab an Attribute from an Assembly
        /// </summary>
        /// <typeparam name="T">Attribute</typeparam>
        /// <param name="input">Assembly to grab the attribute from</param>
        /// <returns>Specified Attribute or null if not found</returns>
        public static T GetAttribute<T>(this Assembly input) where T : Attribute
        {
            return (input.GetCustomAttributes(typeof(T), false).FirstOrDefault() as T);
        }
    }
}
