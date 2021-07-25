using System;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;
using Nez.UI;

namespace Endorblast.DBase
{
    public class LoadCharacterLevelCmd : DatabaseCmd
        {
        
            public int GrabLevel(int characterID)
            {

                var charaInfo = new CharacterInformation();
            
                con = null;
                reader = null;

                try
                {
                    con = new MySqlConnection(DBStr);
                    con.Open();
                
                
                    // Database String && Variables
                    string cmdText = "SELECT Level FROM characters_stats WHERE CharacterID='" + characterID + "';";

                    // Unimportant
                    MySqlCommand cmd = new MySqlCommand(cmdText, con);
                    reader = cmd.ExecuteReader();
                    int level = 0;
                    
                    while (reader.Read())
                    {
                        // Setup Stuff....
                        level = reader.GetInt32(0);
                    }

                    return level;

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
                    }
                }

                return 0;
            }
    }
}