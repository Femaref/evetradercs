using System;

namespace ClassExtenders
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