using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Visual.View;
using EveTrader.Core.Services;
using EveTrader.Core.Collections.ObjectModel;
using System.Reflection;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class PriceLookupSettingViewModel : ViewModel<IPriceLookupSettingView>, ISettingsPage
    {
        private readonly IPriceSourceSelector selector;

        public SmartObservableCollection<Type> PriceGrabbers { get; private set; }
        public SmartObservableCollection<MethodInfo> Methods { get; private set; }

        public Type SelectedSource
        {
            get { return selector.CurrentSource; }
            set
            {
                selector.CurrentSource = value;
                RaisePropertyChanged("SelectedSource");
                RefreshMethods();
            }
        }

        private void RefreshMethods()
        {
            Methods.Clear();

            if (SelectedSource != null)
            {
                foreach (MethodInfo mi in SelectedSource.GetInterfaceMap(typeof(IPriceLookup)).TargetMethods)
                {
                    if (mi.IsDefined(typeof(LookupMethodAttribute), false))
                        Methods.Add(mi);
                }
            }
        }

        public MethodInfo SelectedMethod
        {
            get { return selector.CurrentMethod; }
            set
            {
                selector.CurrentMethod = value;
                RaisePropertyChanged("SelectedMethod");
            }
        }



        [ImportingConstructor]
        public PriceLookupSettingViewModel(IPriceLookupSettingView view, IPriceSourceSelector selector)
            : base(view)
        {
            this.selector = selector;

            PriceGrabbers = new SmartObservableCollection<Type>(view.BeginInvoke);
            Methods = new SmartObservableCollection<MethodInfo>(view.BeginInvoke);

            RefreshPriceGrabbers();
            SelectedSource = selector.CurrentSource;
            SelectedMethod = selector.CurrentMethod;
            
        }

        private void RefreshPriceGrabbers()
        {
            PriceGrabbers.AddRange(selector.LookupServices.Select(l => l.GetType()));
        }

        public string Name
        {
            get { return "Price Lookup Settings"; }
        }

        public int Index
        {
            get { return 2; }
        }
    }
}
