using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;
using System.Collections.ObjectModel;
using MoreLinq;
using System.ComponentModel.Composition;
using EveTrader.Core.ViewModel.Display;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class PriceCacheViewModel : ViewModel<IPriceCacheView>
    {
        private readonly TraderModel iModel;
        private readonly StaticModel iStaticData;

        public ObservableCollection<DisplayPriceCache> Prices { get; set; }

        [ImportingConstructor]
        public PriceCacheViewModel(IPriceCacheView view, TraderModel tm, StaticModel sm)
            : base(view)
        {
            iModel = tm;
            iStaticData = sm;

            Prices = new ObservableCollection<DisplayPriceCache>();

            Refresh();
        }

        public void Refresh()
        {
            Prices.Clear();

            var x = iModel.CachedPriceInfo.Select(c => new DisplayPriceCache()
                {
                    TypeID = c.TypeID,
                    BuyPrice = c.BuyPrice,
                    SellPrice = c.SellPrice
                }).ToList();
            x.ForEach(c =>
            {
                c.TypeName = iStaticData.invTypes.First(ty => ty.typeID == c.TypeID).typeName;
                
            });
            x.OrderBy(c => c.TypeName).ForEach(c => Prices.Add(c));


        }
    }
}
