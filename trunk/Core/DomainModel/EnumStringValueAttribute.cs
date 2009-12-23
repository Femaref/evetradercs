using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Core.DomainModel
{
    public class EnumStringValueAttribute : Attribute
    {
        public string Value { get; set; }

        public EnumStringValueAttribute(string value) : base()
        {
            this.Value = value;
        }
    }
}
