using System;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class AccountExistCmd : DatabaseCmd
    {
        public bool UserExist(string username)
        {

            bool accountExists = false;
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);

                con.Open();

                Console.WriteLine("MySQL DB Connected");
                string cmdText = "SELECT Username FROM accounts WHERE username='" + username + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                int accountID = 0;

                while (reader.Read())
                {
                    if (reader.GetString(0).ToLower() == username.ToLower())
                        accountExists = true;
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

            return accountExists;
        }
    }
}