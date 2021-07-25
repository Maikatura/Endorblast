using System;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class AccountIDCmd : DatabaseCmd
    {
        
        
        public int GetAccountID(string username)
        {
            
            int accountID = 0;
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(DBStr);

                con.Open();

                Console.WriteLine("MySQL DB Connected");
                string cmdText = "SELECT id FROM accounts WHERE username='" + username + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    accountID = reader.GetInt32(0);
                }
                
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

            return accountID;
        }
    }
}