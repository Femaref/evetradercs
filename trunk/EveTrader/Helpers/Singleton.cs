using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Helpers
{
    public abstract class Singleton<T> where T:new()
    {
        private static T instance;
        private static bool isInitialized = false;

        public static T Instance
        {
            get
            {
                if (!isInitialized)
                {
                    instance = new T();
                    isInitialized = true;
                }

                return instance;
            }
            set
            {
                instance = value;
            }
        }
    }
}
