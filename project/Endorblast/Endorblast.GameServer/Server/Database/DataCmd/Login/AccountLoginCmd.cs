using System;
using MySql.Data.MySqlClient;

namespace Endorblast.GameServer.Login.DataCmd
{
    public class AccountLoginCmd
    {
        public bool GetLoginAccount(string username, string password)
        {
            
            string str = $@"server={Database.Instance.ip};database={Database.Instance.database};"
                         + $@"userid={Database.Instance.user};password={Database.Instance.pass};";
            
            Console.WriteLine(username);
            Console.WriteLine(password);
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");
                string cmdText = "SELECT Username, Password, id FROM accounts WHERE username='" + username + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                
                int accountID = 0;

                while (reader.Read())
                {
                    accountID = reader.GetInt32(0);
                }
                
                bool rightPassword = new AccountPasswordCheckCmd().IsPasswordRight(accountID, password);

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