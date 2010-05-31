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

namespace EveTrader.Core.ViewModel
{
    public class ManageAccountsViewModel : ViewModel<IManageAccountsView>
    {
        private readonly TraderModel iModel;

        public event CancelEventHandler Closing;
        public ObservableCollection<Characters> CurrentCharacters { get; private set; }


        public ManageAccountsViewModel(IManageAccountsView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
            CurrentCharacters = new ObservableCollection<Characters>();
            view.Closing += new System.ComponentModel.CancelEventHandler(ViewCore_Closing);
            Refresh();
        }

        void ViewCore_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnClosing(e);
        }

        private void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            CancelEventHandler handler = Closing;
            if (handler != null)
                handler(this, e);
        }


        public void Show()
        {
            this.ViewCore.Show();
        }

        public void Shutdown()
        {
            iModel.Dispose();
        }

        public bool AddAccount(Accounts account)
        {
            try
            {
                iModel.AddToAccounts(account);
                Refresh();
                return true;
            }
            catch (Exception ex)
            {
                iModel.WriteToLog(ex.ToString(), "AccountEntityViewModel.AddAccount");
                return false;
            }
        }
        public bool AddAccount(long userID, string apikey)
        {
            return AddAccount(Model.Accounts.CreateAccounts(userID, apikey));

        }
        public bool RemoveAccount(long userID)
        {
            return RemoveAccount(iModel.Accounts.Where(a => a.ID == userID).First());
        }
        public bool RemoveAccount(Accounts account)
        {
            try
            {
                iModel.DeleteObject(account);
                iModel.SaveChanges();
                Refresh();
                return true;
            }
            catch (Exception ex)
            {
                iModel.WriteToLog(ex.ToString(), "AccountEntityViewModel.RemoveAccount");
                return false;
            }
        }

        public bool AddEntity(Entities entity, Accounts account)
        {
            try
            {
                account.Entities.Add(entity);
                iModel.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                iModel.WriteToLog(ex.ToString(), "AccountEntityViewModel.AddEntity");
                return false;
            }
        }
        public bool AddEntity(Entities entity, long userID)
        {
            var account = iModel.Accounts.Where(a => a.ID == userID);
            if (account.Count() == 0)
                return false;
            return AddEntity(entity, account.First());
        }
        public bool RemoveEntity(Entities entity, Accounts account)
        {
            try
            {
                account.Entities.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                iModel.WriteToLog(ex.ToString(), "AccountEntityViewModel.RemoveAccount");
                return false;
            }
        }
        public bool RemoveEntity(Entities entity, long userID)
        {
            var account = iModel.Accounts.Where(a => a.ID == userID);
            if (account.Count() == 0)
                return false;
            return RemoveEntity(entity, account.First());
        }

        public void Refresh()
        {
            CurrentCharacters.Clear();
            iModel.Entity.OfType<Characters>().ToList().ForEach(x => CurrentCharacters.Add(x));
        }
    }
}
