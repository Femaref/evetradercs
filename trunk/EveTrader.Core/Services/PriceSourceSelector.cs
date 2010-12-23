using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Reflection;
using System.ComponentModel;
using EveTrader.Core.Model;
using System.Linq.Expressions;

namespace EveTrader.Core.Services
{
    [Export(typeof(IPriceSourceSelector))]
    public class PriceSourceSelector : IPriceSourceSelector, INotifyPropertyChanged
    {
        [ImportingConstructor]
        public PriceSourceSelector(ISettingsProvider settings, [ImportMany] IEnumerable<IPriceLookup> lookups)
        {
            this.settings = settings;
            this.LookupServices = lookups;
            Load();
        }

        private readonly object dirtyLock = new object();
        private bool dirty = false;

        private void Load()
        {
            if (settings.PriceSource == "")
            {
                CurrentSource = LookupServices.First().GetType();
                CurrentMethod = CurrentSource.GetInterfaceMap(typeof(IPriceLookup)).TargetMethods.First(t => t.Name == settings.PriceMethod && t.IsDefined(typeof(LookupMethodAttribute), false));

                if (CurrentSource == null || CurrentMethod == null)
                    throw new Exception("No suitable price selector found!");
            }

            CurrentSource = LookupServices.Where(l => l.GetType().Name == settings.PriceSource).Select(l => l.GetType()).SingleOrDefault();

            if (CurrentSource != null)
                CurrentMethod = CurrentSource.GetInterfaceMap(typeof(IPriceLookup)).TargetMethods.SingleOrDefault(t => t.Name == settings.PriceMethod && t.IsDefined(typeof(LookupMethodAttribute), false));
        }

        private void Save()
        {
            settings.PriceSource = CurrentSource != null ? CurrentSource.Name : "";
            settings.PriceMethod = CurrentMethod != null ? CurrentMethod.Name : "";
        }

        private readonly ISettingsProvider settings;
        private IEnumerable<IPriceLookup> iLookupServices = new List<IPriceLookup>();

        public IEnumerable<IPriceLookup> LookupServices
        {
            get
            {
                return iLookupServices;
            }
            set
            {
                iLookupServices = value;
            }
        }

        private Type currentSource;

        public Type CurrentSource
        {
            get { return currentSource; }
            set
            {
                lock (dirtyLock)
                {
                    currentSource = value;
                    RaisePropertyChanged("CurrentSource");
                    if (value != null && CurrentMethod != null)
                    {
                        CurrentMethod = CurrentSource
                            .GetInterfaceMap(typeof(IPriceLookup))
                            .TargetMethods.SingleOrDefault(
                                    l => l.Name == CurrentMethod.Name
                                    && l.IsDefined(typeof(LookupMethodAttribute), false));
                        dirty = true;
                        Save();
                    }
                }
            }
        }

        private MethodInfo currentMethod;

        public MethodInfo CurrentMethod
        {
            get { return currentMethod; }
            set
            {
                lock (dirtyLock)
                {
                    currentMethod = value;
                    RaisePropertyChanged("CurrentMethod");
                    if (currentMethod != null)
                    {
                        dirty = true;
                        Save();
                    }
                }
            }
        }

        private Func<long, OrderType, long, decimal> currentFunc;
        public decimal Current(long typeID, OrderType type, long regionID = 10000002)
        {
            lock (dirtyLock)
            {
                //generates new Func<long, OrderType, long, decimal>
                if (dirty)
                {
                    ParameterExpression peID = Expression.Parameter(typeof(long), "typeID");
                    ParameterExpression peOT = Expression.Parameter(typeof(OrderType), "orderType");
                    ParameterExpression peRID = Expression.Parameter(typeof(long), "regionID");

                    var exp = Expression.Lambda<Func<long, OrderType, long, decimal>>(
                        Expression.Call(
                            Expression.Constant(LookupServices.Single(p => p.GetType() == CurrentSource)), 
                                CurrentMethod, 
                                peID, peOT, peRID), 
                        peID, peOT, peRID);

                    currentFunc = exp.Compile();
                    dirty = false;
                }

                return currentFunc(typeID, type, regionID);
            }
        }


        public void ChangeLookup(string name)
        {
            throw new NotImplementedException();
        }
        public void ChangeMethod(string name)
        {
            throw new NotImplementedException();
        }
        public void ChangeLookup(Type type)
        {
            throw new NotImplementedException();
        }
        public void ChangeMethod(MethodBase method)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }
    }
}
