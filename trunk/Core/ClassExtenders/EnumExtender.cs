using System;
using System.Reflection;
using Core.DomainModel;

namespace Core.ClassExtenders
{
    public static class EnumExtender
    {
        public static string StringValue(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            EnumStringValueAttribute[] attributes = (EnumStringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumStringValueAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Value;
            }

            return value.ToString();
        }     
   
        /*
        public static T GetAttribute<T>(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            T[] attributes = (T[]) fieldInfo.GetCustomAttributes(typeof(T), false);

            if (attributes.Length > 0)
            {
                return attributes[0];
            }
            else
            {
                return null;
            }
        }
         * */
    }
}
