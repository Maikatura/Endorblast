using System;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class AccountCharacterExistCmd : DatabaseCmd
    {
        public bool GetCharacter(string accountName, int characterId)
        {
            var accountID = GetNameID(accountName);
            var list = new LoadCharactersDBCmd().LoadAllCharacters(accountID);

            for (int i = 0; i < list.Count; i++)
                if (list[i].ID == characterId)
                    return true;
            
            return false;
        }

        private int GetNameID(string accountName)
        {
            return new AccountIDCmd().GetAccountID(accountName);
        }

    }
}