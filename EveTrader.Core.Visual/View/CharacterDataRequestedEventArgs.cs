using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Visual.View
{
    public class CharacterDataRequestedEventArgs : EventArgs
    {
        public long UserID { get; set; }
        public string ApiKey { get; set; }
        public CharacterDataRequestedEventArgs(long userID, string apikey)
        {
            UserID = userID;
            ApiKey = apikey;
        }
    }
}
