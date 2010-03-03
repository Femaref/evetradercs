using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace EveTrader.Helpers
{
    public class ObjectAddedEventArgs : EventArgs
    {
        Type ObjectType { get; set; }
        IGenericObject AddedObject { get; set; }

        public ObjectAddedEventArgs(Type objectType, IGenericObject obj)
        {
            ObjectType = objectType;
            AddedObject = obj;
        }
    }
}
