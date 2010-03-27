using System.Collections.Generic;

namespace Core.DomainModel
{
    public interface IGenericObject<T> : IGenericObject
    {
        IEqualityComparer<T> GetComparer();
    }

    public interface IGenericObject
    {
        /// <summary>
        /// Unique for the current run
        /// </summary>
        int ObjectID { get; set; }
    }
}
