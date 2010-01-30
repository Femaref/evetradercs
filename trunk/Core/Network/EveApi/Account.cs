using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Network
{
    public class Account
    {
        public int UserID { get; set; }
        public string ApiKey { get; set;}
        public int CharacterID { get; set; }

        public override string ToString()
        {
            return "Account[" + UserID + "," + ApiKey + "," + CharacterID + "]";
        }
    }
}
