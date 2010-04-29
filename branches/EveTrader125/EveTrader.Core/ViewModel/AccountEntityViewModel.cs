using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using System.ComponentModel;
using System.Waf.Applications;
using EveTrader.Core.View;
using System.Collections.ObjectModel;

namespace EveTrader.Core.ViewModel
{
    public class AccountEntityViewModel : ViewModel<IAccountEntityView>
    {
        TraderModel iModel;

        public ObservableCollection<Accounts> Accounts { get; private set; }


        public AccountEntityViewModel(IAccountEntityView view, TraderModel te) : base(view)
        {
            iModel = te;
            Refresh();
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
                iModel.WriteToLog(ex.ToString());
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
                iModel.WriteToLog(ex.ToString());
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
                iModel.WriteToLog(ex.ToString());
                return false;
            }
        }
        public bool AddEntity(Entities entity, long userID)
        {
            var account = iModel.Accounts.Where(a => a.ID == userID);
            if(account.Count() == 0)
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
                iModel.WriteToLog(ex.ToString());
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
            Accounts.Clear();
            iModel.Accounts.ToList().ForEach(x => Accounts.Add(x));
        }
    }
}
