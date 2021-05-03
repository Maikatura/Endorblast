using System;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadCharacterByNameCmd : DatabaseCmd
    {
        public static CharacterInformation GrabCharacterByName(string name)
        {

            var charaInfo = new CharacterInformation();
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "SELECT * FROM characters WHERE CharacterName='" + name + "';";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Setup Stuff....
                    charaInfo.CharacterId = reader.GetInt32(0);
                    charaInfo.AccountId = reader.GetInt32(1);
                    charaInfo.CharacterName = reader.GetString(2);
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

            return charaInfo;
        }
    }
}