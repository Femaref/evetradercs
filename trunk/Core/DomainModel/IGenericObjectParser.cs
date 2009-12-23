using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public interface IGenericObjectParser<T>
    {
        T Parse();
    }
}
