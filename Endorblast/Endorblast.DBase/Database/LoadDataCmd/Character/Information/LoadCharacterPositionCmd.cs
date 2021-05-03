using System;
using Endorblast.Lib.Game.Utils;
using Microsoft.Xna.Framework;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadCharacterPositionCmd : DatabaseCmd
    {
        public static WorldInfo GrabCharacterPosition(int characterID)
        {
            
            
            
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "SELECT * FROM characters_positions WHERE CharacterID='" + characterID + "';";
                
                
                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                int worldID = 0;
                float x = 0, y = 0;
                Vector2 position;
                
                while (reader.Read())
                {
                    // Setup Stuff....
                    worldID = reader.GetInt32(2);
                    x = reader.GetFloat(3);
                    y = reader.GetFloat(4);
                }
                
                
                // Build Character First
                return new WorldInfo(worldID, x,y);;
                


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

            return null;
        }
    }
}