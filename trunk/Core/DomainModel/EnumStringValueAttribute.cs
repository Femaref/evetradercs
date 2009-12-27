using System;

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