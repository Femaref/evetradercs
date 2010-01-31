using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Migration
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TargetFileAttribute : Attribute
    {
        public string Target { get; private set; }

        public TargetFileAttribute(string target)
        {
            Target = target;
        }
    }
}
