using System;

namespace EveTrader.Core.ClassExtenders
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