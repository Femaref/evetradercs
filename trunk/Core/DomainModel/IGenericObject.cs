using System.Collections.Generic;

namespace Core.DomainModel
{
    public interface IGenericObject<T>
    {
        IEqualityComparer<T> GetComparer();
    }
}
