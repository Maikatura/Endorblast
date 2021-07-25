using System;
using Endorblast.Library.Enums;
using Endorblast.LoginServer.Data;
using Microsoft.Xna.Framework;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadCharacterLocationCmd : DatabaseCmd
    {
        public LocationData LoadLocation(int characterID)
        {
            var location = new LocationData();
            
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
                float x = 0, y = 0;
                    
                while (reader.Read())
                {
                    // Setup Stuff....
                    location.mapType = (MapType)reader.GetInt32(2);
                    x = reader.GetFloat(3);
                    y = reader.GetFloat(4);
                    location.Position = new Vector2(x, y);
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
            
            return location;
        }
    }
}