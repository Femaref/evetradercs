using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EveTrader.Core.Migration
{
    public static class CustomAttributeProviderExtensions
    {
        public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider provider) where T : Attribute
        {
            return GetCustomAttributes<T>(provider, true);
        }

        public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider provider, bool inherit) where T : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            T[] attributes = provider.GetCustomAttributes(typeof(T), inherit) as T[];
            if (attributes == null)
            {   // WORKAROUND: Due to a bug in the code for retrieving attributes
                // from a dynamic generated parameter, GetCustomAttributes can return
                // an instance of an object[] instead of T[], and hence the cast above
                // will return null.
                return new T[0];
            }

            return attributes;
        }
    }
}
