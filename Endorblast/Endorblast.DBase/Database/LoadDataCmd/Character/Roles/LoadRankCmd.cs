using System;
using Endorblast.Lib.Game.Utils;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
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

            // Todo : Fix so if a rank gets removed it will set all that players rank back to rank with lowers permission Level
            
            Console.WriteLine("Rank Does not Exist!");

            return null;
        }
    }
}