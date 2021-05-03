using System;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadAccountInfoCmd : DatabaseCmd
    {


        public AccountInfo LoadAccountInfo(int accountID)
        {
            con = null;
            reader = null;

            try
            {
                string cmdText = "SELECT id, AccountID, LastOnline, PremiumCurrency FROM accounts_information WHERE AccountID='" + accountID + "';";
                
                con = new MySqlConnection(DBStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                var accountInformation = new AccountInfo();

                while (reader.Read())
                {
                    accountInformation.AccountID = reader.GetInt32(1);
                    accountInformation.LastOnline = reader.GetDateTime(2);
                    accountInformation.PremiumCurrency = reader.GetInt32(4);
                }

                return accountInformation;
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            
            return null;
        }
        
    }
}