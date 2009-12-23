using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public interface IGenericObject<T>
    {
        IEqualityComparer<T> GetComparer();
    }
}
