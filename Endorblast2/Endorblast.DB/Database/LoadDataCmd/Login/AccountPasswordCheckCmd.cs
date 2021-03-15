using System;
using MySql.Data.MySqlClient;

namespace Endorblast.DB
{
    public class AccountPasswordCheckCmd : DatabaseCmd
    {
        public bool IsPasswordRight(int accountID, string password)
        {
            
            
            con = null;
            reader = null;

            try
            {
                
                string cmdText = "SELECT id, AccountID, Password FROM accounts_password WHERE AccountID='" + accountID + "';";
                
                con = new MySqlConnection(DBStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                bool rightPassword = false;

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(password, reader.GetString(2)))
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