using System;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase.LoadDataCmd.Data
{
    public class GetTokenCmd : DatabaseCmd
    {
        public string GetToken(string username)
        {
            con = null;
            reader = null;
            string token = "";
            
            var item = new ItemData();

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                // Database String && Variables
                string cmdText = "SELECT token FROM accounts_token WHERE username='"+ username +"';";

                
                
                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    token = reader.GetString(0);
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

            return token;
        }
    }
}