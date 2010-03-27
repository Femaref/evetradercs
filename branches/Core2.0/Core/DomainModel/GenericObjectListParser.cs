using System.Collections.Generic;

namespace Core.DomainModel
{
    interface GenericObjectListParser<T>
    {
        IList<T> Parse();
    }
}
