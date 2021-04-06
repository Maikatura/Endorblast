using System;

namespace Endorblast.Lib.Game.Data
{
    public class AccountInfo
    {

        private int accountID;
        private DateTime lastOnline;
        private int premiumCurrency;
        


        #region Get/Setters
        
        public int AccountID
        {
            get => accountID;
            set => accountID = value;
        }
        
        public DateTime LastOnline
        {
            get => lastOnline;
            set => lastOnline = value;
        }
        
        public int PremiumCurrency
        {
            get => PremiumCurrency;
            set => PremiumCurrency = value;
        }
        
        #endregion
    }
}