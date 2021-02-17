using System;
using Endorblast.Lib;
using Endorblast.LoginServer.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.GameServer.Login.DataCmd
{
    public class AccountPasswordCheckCmd
    {
        public bool IsPasswordRight(int accountID, string password)
        {
            string str = $@"server={Database.Instance.ip};database={Database.Instance.database};"
                         + $@"userid={Database.Instance.user};password={Database.Instance.pass};";
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                ConsoleHelper.WriteLine($"MySQL Connected for ID: {accountID}", ServerErrors.Info);
                string cmdText = "SELECT id, AccountID, Password FROM accounts_password WHERE AccountID='" + accountID + "';";
                
                con = new MySqlConnection(str);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                bool rightPassword = false;

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(password, reader.GetString(3)))
                    {
                        rightPassword = true;
                    }
                }

                return rightPassword;

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
            
            return false;
        }
    }
}