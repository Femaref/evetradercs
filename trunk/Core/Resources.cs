using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveObjects;

namespace Core
{
    public class Resources
    {
        private static Resources instance = null;
        
        public static Resources Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Resources();
                }

                return instance;
            }
        }

        public Objects EveObjects
        {
            get
            {
                return Objects.Instance;
            }
        }
    }
}
