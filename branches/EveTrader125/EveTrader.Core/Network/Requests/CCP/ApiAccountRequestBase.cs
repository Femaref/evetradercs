using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Net.Requests.CCP
{
    public abstract class ApiAccountRequestBase<T> : ApiRequestBase<T>
    {
        private readonly Accounts iAccount;

        protected override string Data
        {
            get
            {
                string output = "";
                foreach (KeyValuePair<string, string> kvp in this.iData)
                {
                    output += string.Format("{0}={1}&", kvp.Key, kvp.Value);
                }
                return output.Substring(0, output.Length-2);
            }
        }
        public ApiAccountRequestBase(Accounts a) :base()
        {
            iAccount = a;
            this.iData.Add("userID", a.ID.ToString());
            this.iData.Add("apiKey", a.ApiKey);
        }
    }
}
