using System;
using Endorblast.Lib.Game.Utils;
using MySql.Data.MySqlClient;

namespace Endorblast.DB
{
    public class LoadCharacterStatsCmd : DatabaseCmd
    {
        public static Stats GrabCharacterStats(int characterID)
        {

            var stat = new Stats();
            
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "SELECT * FROM characters_stats WHERE CharacterID='" + characterID + "';";

                int level = 0, exp = 0, ap = 0, dp = 0;
                
                
                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Setup Stuff....
                    level = reader.GetInt32(2);
                    exp = reader.GetInt32(3);
                }
                
                // Build Character First
                stat.Level = level;
                stat.Exp = exp;
                
                // Return Stuff Below
                
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

            return stat;
        }
    }
}