using System;
using MySql.Data.MySqlClient;

namespace Endorblast.DB
{
    public class ServerAuth : DatabaseCmd
    {

        public int GetServerAuthCode()
        {
            
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(DBStr);

                con.Open();

                Console.WriteLine("MySQL DB Connected");
                string cmdText = "SELECT secret FROM server_info;";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                
                int secretToken = 0;

                while (reader.Read())
                    secretToken = reader.GetInt32(0);
                
                return secretToken;
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