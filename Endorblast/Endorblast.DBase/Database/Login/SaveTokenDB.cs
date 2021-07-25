using System;
using MySql.Data.MySqlClient;
using Nez.UI;

namespace Endorblast.DBase.Login
{
    public class SaveTokenDB : DatabaseCmd
    {

        public void UpdateOrSaveToken(string username, string token)
        {
            con = null;
            reader = null;



            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();


                bool tokenExist = false;
                string testCmd = "SELECT username FROM accounts_token WHERE username='" + username.ToUpper() + "';";
                MySqlCommand testCMD = new MySqlCommand(testCmd, con);
                reader = testCMD.ExecuteReader();
                while (reader.Read())
                {
                    tokenExist = (reader.GetString(0) != null);
                }
                
                con.Close();
                
                // Database String && Variables
                
                string cmdText = "INSERT INTO accounts_token (username, token) VALUES (@Username, @Token);";
                
                if (tokenExist)
                {
                    cmdText = "UPDATE accounts_token SET "+
                              "username='"+ username +"'," + 
                              "token='"+ token +"'" +
                              "WHERE username='"+username.ToUpper()+"';";
                }
                
                con.Open();
                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);

                if (!tokenExist)
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToUpper());
                    cmd.Parameters.AddWithValue("@Token", token);
                }

                cmd.ExecuteNonQuery();
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
                    con.Dispose();
                }
            }
        }

        
        
    }
}