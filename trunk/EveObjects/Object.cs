using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveObjects
{
    public class Object
    {
        public double Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
