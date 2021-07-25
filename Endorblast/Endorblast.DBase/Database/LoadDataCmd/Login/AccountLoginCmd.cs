using System;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class AccountLoginCmd : DatabaseCmd
    {
        public int GetLoginAccount(string username, string password)
        {
            Console.WriteLine(username);
            Console.WriteLine(password);
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(DBStr);

                con.Open();

                Console.WriteLine("MySQL DB Connected");
                string cmdText = "SELECT Username, id FROM accounts WHERE username='" + username + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                int accountID = 0;

                while (reader.Read())
                {
                    accountID = int.Parse(reader["id"].ToString());
                }


                bool rightPassword = new AccountPasswordCheckCmd().IsPasswordRight(accountID, password);

                if (rightPassword)
                    return accountID;

                return 0;
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

            return 0;
        }
    }
}