using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    interface GenericObjectListParser<T>
    {
        IList<T> Parse();
    }
}
