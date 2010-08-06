using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using EveTrader.Core.Network.Requests.CCP;
using EveTrader.Core.Collections.ObjectModel;
using EveTrader.Core.ViewModel.Display;
using MoreLinq;
using EveTrader.Core.Controllers;
using EveTrader.Core.Updater.CCP;

namespace EveTrader.Core.ViewModel
{
    public class ManageAccountsViewModel : ViewModel<IManageAccountsView>
    {
        private readonly TraderModel iModel;
        private readonly IUpdateService iUpdater;
        private readonly EntityFactory iFactory;

        private bool iDataRequestable = false;
        
        public SmartObservableCollection<Characters> CurrentCharacters { get; private set; }
        public SmartObservableCollection<Selectable<Characters>> RequestedCharacters {get; private set;}
        public bool DataPresent
        {
            get
            {
                return RequestedCharacters.Count() > 0;
            }
        }
        public bool DataRequestable
        {
            get
            {
                return iDataRequestable;
            }
            set
            {
                iDataRequestable = value;
                RaisePropertyChanged("DataRequestable");
            }
        }


        public ManageAccountsViewModel(IManageAccountsView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, IUpdateService us, EntityFactory ef)
            : base(view)
        {
            iModel = tm;
            iUpdater = us;
            iFactory = ef;

            CurrentCharacters = new SmartObservableCollection<Characters>(view.Invoke);
            RequestedCharacters = new SmartObservableCollection<Selectable<Characters>>(view.Invoke);
            DataRequestable = true;
            view.Closing += new System.ComponentModel.CancelEventHandler(ViewCore_Closing);
            view.DataRequested += new EventHandler<CharacterDataRequestedEventArgs>(view_DataRequested);
            view.AddCharacters += new EventHandler(view_AddCharacters);
            view.AbortRequest += new EventHandler(view_AbortRequest);
            Refresh();
        }

        public void Show()
        {
            this.ViewCore.Show();
        }
        public void Shutdown()
        {
            this.ViewCore.Close();
        }
        public void Refresh()
        {
            CurrentCharacters.Clear();
            iModel.Entity.OfType<Characters>().ToList().ForEach(x => CurrentCharacters.Add(x));
        }

        private void view_AbortRequest(object sender, EventArgs e)
        {
            RequestedCharacters.Clear();
            DataRequestable = false;
            RaisePropertyChanged("DataPresent");
        }
        private void view_AddCharacters(object sender, EventArgs e)
        {
            long id = RequestedCharacters.First().Item.Account.ID;
            Accounts account = iModel.Accounts.First(a => a.ID == id);
            account.Entities.Clear();
            foreach (Characters c in RequestedCharacters.Where(s => s.IsSelected))
            {
                Characters cache = iFactory.CreateCharacter(c.ID, account);
                cache.Corporation = iFactory.CreateCorporation(c.Corporation.ID, account, c.ID);
                iModel.SaveChanges();

                iUpdater.Update(cache);
                iUpdater.Update(cache.Corporation);
            }
            



            RequestedCharacters.Clear();
            DataRequestable = false;
            RaisePropertyChanged("DataPresent");
        }
        private void view_DataRequested(object sender, CharacterDataRequestedEventArgs e)
        {
            var account = iModel.Accounts.Where(a => a.ID == e.UserID).FirstOrDefault();
            if (account == null)
            {
                account = new Accounts() { ID = e.UserID, ApiKey = e.ApiKey };
                iModel.Accounts.AddObject(account);
            }
            if (account.ApiKey != e.ApiKey)
                account.ApiKey = e.ApiKey;
            iModel.SaveChanges();

            CharacterListRequest clr = new CharacterListRequest(new Accounts() { ID = account.ID, ApiKey = account.ApiKey }, iModel.StillCached, iModel.SaveCache, iModel.LoadCache);
            var requestedCharacters = clr.Request().Select(c => new Selectable<Characters>(c, false));

            RequestedCharacters.AddRange(requestedCharacters);

            DataRequestable = false;
            RaisePropertyChanged("DataPresent");
        }
        private void ViewCore_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnClosing(e);
        }
        private void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            CancelEventHandler handler = Closing;
            if (handler != null)
                handler(this, e);
        }

        public event CancelEventHandler Closing;
    }
}
