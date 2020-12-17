

using System;
using MySql.Data.MySqlClient;

namespace Endorblast.LoginServer.Login
{
    public class Database
    {
        
        private static Database instance = new Database();
        public static Database Instance => instance;

        
        string str = @"server=localhost;database=gamerenginenet;userid=root;password=;";

        public bool GetLoginAccount(string username, string password)
        {
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT username, password FROM users;";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                bool rightLoggin = false;

                while (reader.Read())
                {
                    if (reader["username"].ToString().ToUpper() == username.ToUpper() &&
                        BCrypt.Net.BCrypt.Verify(password, reader["password"].ToString())
                    )
                    {
                        rightLoggin = true;
                    }
                }

                if (rightLoggin)
                {
                    return rightLoggin;
                }
                else
                {
                    return rightLoggin;
                }

            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                return false;
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