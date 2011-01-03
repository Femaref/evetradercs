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
            this.LookupServices = lookups.Where(l => !l.GetType().IsDefined(typeof(LookupDeprecatedAttribute), false));

            if (settings.PriceSource == "" || !LookupServices.Any(l => l.GetType().Name == settings.PriceSource && !l.GetType().IsDefined(typeof(LookupDeprecatedAttribute), false)))
            {
                currentSource = LookupServices.FirstOrDefault().GetType();
            }
            else
            {
                currentSource = LookupServices.Where(l => l.GetType().Name == settings.PriceSource && !l.GetType().IsDefined(typeof(LookupDeprecatedAttribute), false)).Select(l => l.GetType()).SingleOrDefault();
            }
            if (settings.PriceMethod == "" || !currentSource.GetInterfaceMap(typeof(IPriceLookup)).TargetMethods.Any(t => t.IsDefined(typeof(LookupMethodAttribute), false) && t.Name == settings.PriceMethod))
            {
                currentMethod = currentSource.GetInterfaceMap(typeof(IPriceLookup)).TargetMethods.FirstOrDefault(t => t.IsDefined(typeof(LookupMethodAttribute), false));
            }
            else
            {
                if (currentSource != null)
                    currentMethod = currentSource.GetInterfaceMap(typeof(IPriceLookup)).TargetMethods.SingleOrDefault(t => t.Name == settings.PriceMethod && t.IsDefined(typeof(LookupMethodAttribute), false));
            }

            if (CurrentSource == null || CurrentMethod == null)
                throw new Exception("No suitable price selector found!");

            RaisePropertyChanged("CurrentSource");
            RaisePropertyChanged("CurrentMethod");
        }

        private readonly object dirtyLock = new object();
        private bool dirty = false;

        private readonly ISettingsProvider settings;
        private IEnumerable<IPriceLookup> lookupServices = new List<IPriceLookup>();

        public IEnumerable<IPriceLookup> LookupServices
        {
            get
            {
                return lookupServices;
            }
            set
            {
                lookupServices = value;
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
                    if (value != null)
                    {
                        if (CurrentMethod != null)
                        {
                            CurrentMethod = CurrentSource
                                .GetInterfaceMap(typeof(IPriceLookup))
                                .TargetMethods.SingleOrDefault(
                                        l => l.Name == CurrentMethod.Name
                                        && l.IsDefined(typeof(LookupMethodAttribute), false));
                        }

                        if (CurrentMethod == null)
                        {
                            CurrentMethod = CurrentSource.GetInterfaceMap(typeof(IPriceLookup))
                                .TargetMethods.FirstOrDefault(l => l.IsDefined(typeof(LookupMethodAttribute), false));
                        }
                        dirty = true;
                        settings.PriceSource = CurrentSource.Name;
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
                        settings.PriceMethod = currentMethod.Name;
                    }
                    else
                    {
                        CurrentMethod = CurrentSource.GetInterfaceMap(typeof(IPriceLookup))
                            .TargetMethods.FirstOrDefault(l => l.IsDefined(typeof(LookupMethodAttribute), false));
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
                if (dirty || currentFunc == null)
                {
                    ParameterExpression expTypeID = Expression.Parameter(typeof(long), "typeID");
                    ParameterExpression expOrderType = Expression.Parameter(typeof(OrderType), "orderType");
                    ParameterExpression expRegionID = Expression.Parameter(typeof(long), "regionID");

                    var exp = Expression.Lambda<Func<long, OrderType, long, decimal>>(
                        Expression.Call(
                            Expression.Constant(LookupServices.Single(p => p.GetType() == CurrentSource)), 
                                CurrentMethod, 
                                expTypeID, expOrderType, expRegionID), 
                        expTypeID, expOrderType, expRegionID);

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
