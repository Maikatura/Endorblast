using System;
using Endorblast.Lib.Game.Utils;
using MySql.Data.MySqlClient;

namespace Endorblast.DB
{
    public class LoadRankCmd : DatabaseCmd
    {
        public static Role GrabAccountRank(int accountID)
        {
            // TODO : Load Every role and that stuff :)

            var rankList = LoadRanksCmd.GrabGameRoles();
            int userRankID = LoadAccountRankIDCmd.GrabGameRoles(accountID);


            foreach (var rank in rankList)
            {
                if (rank.RoleID == userRankID)
                {
                    Console.WriteLine(rank.RoleName);
                    return rank;
                }
                    
            }
            
            

            return null;
        }
    }
}