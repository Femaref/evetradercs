using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model.Trader;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using EveTrader.Core.Network.Requests.CCP;
using EveTrader.Core.Collections.ObjectModel;
using EveTrader.Core.ViewModel.Display;
using MoreLinq;
using EveTrader.Core.Controllers;
using EveTrader.Core.Updater.CCP;
using EveTrader.Core.Services;
using System.Windows.Input;

namespace EveTrader.Core.ViewModel
{
    public class ManageAccountsViewModel : ViewModel<IManageAccountsView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;
        private readonly IUpdateService iUpdater;
        private readonly EntityFactory iFactory;

        private DelegateCommand iRequestDataCommand;
        private DelegateCommand iAbortRequestCommand;
        private DelegateCommand iAddCharactersCommand;
        private DelegateCommand iUpdateAccountCommand;

        private object iUpdaterLock = new object();

        public ICommand RequestDataCommand
        {
            get { return iRequestDataCommand; }
        }
        public ICommand AbortRequestCommand
        {
            get { return iAbortRequestCommand; }
        }
        public ICommand AddCharactersCommand
        {
            get { return iAddCharactersCommand; }
        }
        public ICommand UpdateAccountCommand
        {
            get { return iUpdateAccountCommand; }
        }

        private long iCurrentUserID;

        public long CurrentUserID
        {
            get { return iCurrentUserID; }
            set
            {
                lock (iUpdaterLock)
                {
                    iCurrentUserID = value;
                    RaisePropertyChanged("CurrentUserID");
                }
            }
        }

        private string iCurrentApiKey;

        public string CurrentApiKey
        {
            get { return iCurrentApiKey; }
            set
            {
                lock (iUpdaterLock)
                {
                    iCurrentApiKey = value;
                    RaisePropertyChanged("CurrentApiKey");
                }
            }
        }

        public Characters CurrentItem
        {
            get { return iCurrentItem; }
            set
            {
                this.iCurrentItem = value;
                RaisePropertyChanged("CurrentItem");
            }
        }



        private bool iDataRequestable = false;
        private bool iDataPresent = false;

        public SmartObservableCollection<Characters> CurrentCharacters { get; private set; }
        public SmartObservableCollection<Selectable<Characters>> RequestedCharacters { get; private set; }
        public bool DataPresent
        {
            get
            {
                return iDataPresent;
            }
            private set
            {
                iDataPresent = value;
                RaisePropertyChanged("DataPresent");
            }
        }
        public bool DataRequestable
        {
            get
            {
                return iDataRequestable;
            }
            private set
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

            iRequestDataCommand = new DelegateCommand(RequestData, () => DataRequestable);
            iAbortRequestCommand = new DelegateCommand(AbortRequest);
            iAddCharactersCommand = new DelegateCommand(AddCharacters, () => DataPresent);
            iUpdateAccountCommand = new DelegateCommand(
                () => 
                { 
                    if (CurrentItem != null) 
                        CurrentUserID = CurrentItem.Account.ID; 
                });

            this.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == "DataRequestable")
                        iRequestDataCommand.RaiseCanExecuteChanged();
                    if (e.PropertyName == "DataPresent")
                        iAddCharactersCommand.RaiseCanExecuteChanged();
                };

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

        private void RequestData()
        {
            lock (iUpdaterLock)
            {
                var account = iModel.Accounts.Where(a => a.ID == CurrentUserID).FirstOrDefault();
                if (account == null)
                {
                    account = new Accounts() { ID = CurrentUserID, ApiKey = CurrentApiKey };
                    iModel.Accounts.AddObject(account);
                }
                if (account.ApiKey != CurrentApiKey)
                    account.ApiKey = CurrentApiKey;
                iModel.SaveChanges();

                CharacterListRequest clr = new CharacterListRequest(new Accounts() { ID = account.ID, ApiKey = account.ApiKey }, iModel.StillCached, iModel.SaveCache, iModel.LoadCache);
                var requestedCharacters = clr.Request().Select(c => new Selectable<Characters>(c, false));

                RequestedCharacters.AddRange(requestedCharacters.Where(s => !account.Entities.Any(e => e.ID == s.Item.ID)));

                DataRequestable = false;
                DataPresent = true;
            }
        }
        private void AbortRequest()
        {
            lock (iUpdaterLock)
            {
                RequestedCharacters.Clear();
                DataRequestable = true;
                DataPresent = false;
            }
        }
        private void AddCharacters()
        {
            lock (iUpdaterLock)
            {
                long id = RequestedCharacters.First().Item.Account.ID;
                Accounts account = iModel.Accounts.First(a => a.ID == id);
                foreach (Characters c in RequestedCharacters.Where(s => s.IsSelected).Where(s => !iModel.Entity.Any(e => e.ID == s.Item.ID)))
                {
                    Characters cache = iFactory.CreateCharacter(c.ID, account);
                    cache.Corporation = iFactory.CreateCorporation(c.Corporation.ID, account, c.ID);
                    iModel.SaveChanges();

                    iUpdater.Update(cache);
                    iUpdater.Update(cache.Corporation);
                }
                RequestedCharacters.Clear();
                DataRequestable = true;
                DataPresent = false;
                Refresh();
            }
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

        #region IRefreshableViewModel Members


        public void DataIncoming(object sender, EntitiesUpdatedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool iUpdating = false;
private  Characters iCurrentItem;

        public bool Updating
        {
            get { return iUpdating; }
            private set
            {
                iUpdating = value;
                RaisePropertyChanged("Updating");
            }
        }

        #endregion
    }
}
