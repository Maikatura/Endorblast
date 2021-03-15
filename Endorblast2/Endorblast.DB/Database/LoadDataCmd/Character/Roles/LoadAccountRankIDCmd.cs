using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Endorblast.DB
{
    public class LoadAccountRankIDCmd: DatabaseCmd
    {
        
        public static int GrabGameRoles(int accountID)
        {
            int roleID = 0;
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "SELECT * FROM roles_users WHERE AccountID='" + accountID + "';";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roleID = reader.GetInt32(2);
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

            return roleID;
        }

    }
}