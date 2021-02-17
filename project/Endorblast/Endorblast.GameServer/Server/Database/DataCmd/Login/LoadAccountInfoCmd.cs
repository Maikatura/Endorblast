using System;
using System.Collections.Generic;
using Endorblast.Lib;
using Endorblast.LoginServer.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.GameServer.Login.DataCmd
{
    public class LoadAccountInfoCmd
    {


        public AccountInfo LoadAccountInfo(int accountID)
        {
            string str = $@"server={Database.Instance.ip};database={Database.Instance.database};"
                         + $@"userid={Database.Instance.user};password={Database.Instance.pass};";
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                ConsoleHelper.WriteLine($"MySQL Connected for ID: {accountID}", ServerErrors.Info);
                string cmdText = "SELECT id, AccountID, LastOnline, PremiumCurrency FROM accounts_information WHERE AccountID='" + accountID + "';";
                
                con = new MySqlConnection(str);
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