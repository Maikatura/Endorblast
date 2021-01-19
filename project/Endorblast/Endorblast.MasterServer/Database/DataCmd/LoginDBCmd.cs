using System;
using MySql.Data.MySqlClient;

namespace Endorblast.LoginServer.Login.DataCmd
{
    public class LoginDBCmd
    {
        public Tuple<bool, int> GetLoginAccount(string username, string password)
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

                bool rightLoggin = false;
                int userID = 0;

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(password, reader["password"].ToString()))
                    {
                        rightLoggin = true;
                        userID = int.Parse(reader["id"].ToString());
                    }
                }

                if (rightLoggin)
                {
                    return new Tuple<bool, int>(rightLoggin, userID);
                }
                else
                {
                    return new Tuple<bool, int>(rightLoggin, 0);
                }

            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                return new Tuple<bool, int>(false, 0);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            
            
        }
    }
}